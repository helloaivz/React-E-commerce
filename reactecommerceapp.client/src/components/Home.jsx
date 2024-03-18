import React from 'react';
import axios from 'axios';


const Base_URL = "https://localhost:7271/";

/*export default function Home() {*/
class Home extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            products: null,
            message: null

        };
    }

    componentDidMount() {
        // Simple GET request using axios
        axios.get(Base_URL + 'GetProducts')
            .then(response => this.setState({ products: response.data }));
    }

    render() {
        const addToCart = id => {
            try {
                const cartResponse = axios.post(Base_URL + `InsertCartItem/${id}`).then(response => this.setState({ message: 'Added to cart successfully' }));
                setTimeout(() => this.setState({ message: '' }), 2000);
            } catch (error) {
                console.error(error);
            }
        }
        const { products, message } = this.state;
        
        return (
            <>
                <div className="my-container mx-auto">
                    <div className="border p-5">
                        <div className="center-header">
                        <h2>List of Products</h2>
                        <div className="clear"></div>

                        <div className="processing" role="status" id="addedtocart">
                            <h6 className="m-0 text-success" > {message} </h6>
                        </div>
                            <br />
                        </div>
                        <div className="grid-view">
                            <div className="row g-5">
                                {
                                    products && products.map((product, index) => {
                                       const imageurl = "src/assets/images/"+product.image;
                                        return <div className="col-3" key={index}>

                                            <div className="grid-view-grid">
                                                <div className="card text-center">
                                                    <div className="overflow-hidden d-flex justify-content-center align-items-center">
                                                        <img src={imageurl} alt="" className="card-img-top" width="100" />
                                                    </div>

                                                    <div className="card-body">
                                                        <h5 className="card-title title"> {product.title} </h5>
                                                        <p className="card-text description"> {product.description} </p>
                                                        <h6 className="card-subtitle my-2 text-primary">Stock: {product.qty} </h6>
                                                        <h5 className="card-text text-success ">Price: ${product.price} </h5>
                                                    </div>
                                                    <div className="card-footer d-grid gap-2">
                                                        <button onClick={() => addToCart(product.id) } type="button" className="btn btn-outline-success">Add to Cart</button>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>;
                                    })
                                }
                            </div>
                        </div>
                    </div>
                </div>
            </>
        );
    }
}

export default Home;