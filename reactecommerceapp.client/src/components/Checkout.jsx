import React from 'react';
import axios from 'axios';


const Base_URL = "https://localhost:7271/";

class Checkout extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            orderNo: null
        };
    }


    homepage() {

        window.location.href = "/";
    }


    componentDidMount() {
        const getOder = axios.post(Base_URL + 'CheckoutComplete').then(response => this.setState({ orderNo: response.data }));
        //if (getOder != null) {
        console.log(getOder);
       // }
    }

    render() {
        const { orderNo } = this.state;
        if (orderNo) {
                return (
                <div className="my-container mx-auto">
                    <div className="border p-5 center-header">
                        <h2>Checkout Complete</h2>
                        <div className="clear"></div>
                        <div className="processing" role="status" id="addedtocart">
                            <h6 className="text-success">Order No. {orderNo} </h6>
                            <h5>Thank you for shopping!</h5>
                        </div>
                        <br />
                    </div>
                </div>
                )
            } else {
                return (
                <div className="my-container mx-auto">
                    <div className="border p-5 center-header">
                            <h2>Please order again!</h2>
                        <br />
                        <button type="button" onClick={this.homepage} className="btn btn-lg btn-outline-success">
                            Go Back to Homepage
                        </button>
                    </div>
                </div>
                )
            }
    }

}

export default Checkout;