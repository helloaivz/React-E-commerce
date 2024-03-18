import React from 'react';
import axios from 'axios';


const Base_URL = "https://localhost:7271/";

class Cart extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            carts: null,
            message: null
        };
    }

    componentDidMount() {
        axios.get(Base_URL + 'GetCartItems').then(response => this.setState({ carts: response.data }));
    }

    checkout() {
        
        window.location.href = "/checkout";
    }

    render() {
        const updateCart = (id, value) => {
            try {
                axios.post(Base_URL + `UpdateCart/${id}/${value}`).then(response => this.setState({ message: 'Cart updated successfully!' }));
                setTimeout(() => this.setState({ message: '' }), 2000);

            } catch (error) {
                console.error(error);
            }
        }
        const removeItem = id => {
            try {
                axios.post(Base_URL + `RemoveItem/${id}`).then(response => this.setState({ message: 'Removed item successfully!' }));
                setTimeout(() => this.setState({ message: '' }), 2000);
                document.cookie = "username=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";

                axios.get(Base_URL + 'GetCartItems')
                    .then(response => setTimeout(() => this.setState({ carts: response.data }), 2000));
                    
            } catch (error) {
                console.error(error);
            }
        }
        const { carts, message } = this.state;
        return (
            <div className="my-container mx-auto">
                <div className="border p-5">
                    <div className="center-header">
                    <h2 className="align-items-center">Shopping Cart</h2>
                    <div className="clear"></div>
                    <div className="processing" role="status" id="addedtocart">
                        <h6 className="text-success"> {message} </h6>
                    </div>
                        <br />
                    </div>

                    <div className="list-view">
                        {
                            carts && carts.map((cart, index) => {
                                const imageurl = "src/assets/images/" + cart.product.image;
                                return <div className="row mb-5" key={cart.transactionid}>
                                    <div className="col">
                                        <div className="list-view">
                                            <div className="card">
                                                <div className="row g-0">
                                                    <div className="col-md-4 overflow-hidden d-flex justify-content-center align-items-center">
                                                        <img src={imageurl} alt="" className="img-fluid rounded-start" width="100" />
                                                    </div>
                                                    <div className="col d-flex flex-column">
                                                        <div className="card-body">
                                                            <h5 className="card-title title">{cart.product.title} </h5>
                                                            <h6 className="card-text text-success ">Price: ${cart.product.price} </h6>
                                                        </div>
                                                        <div className="card-footer text-muted d-grid gap-2">
                                                                Qty:
                                                                <input type="number" name="qty" defaultValue={cart.qty} onChange={(e) => updateCart(cart.productId, e.target.value)} /> &nbsp;
                                                            <button onClick={() => removeItem(cart.productId)} type="button" className="btn btn-outline-danger">
                                                                Remove
                                                            </button>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>;
                            })
                        }
                    </div>
                    <div className="align-content-lg-end center-header">
                        <button type="button" onClick={this.checkout} className="btn btn-lg btn-outline-success">
                            Proceed to Checkout
                        </button>
                    </div>
                </div>
            </div>
        );
    }
}

export default Cart;