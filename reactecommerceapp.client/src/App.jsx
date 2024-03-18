import React from 'react';
import Home from './components/Home';
import Cart from './components/Cart';
import Checkout from './components/Checkout';

import { Routes, Route } from 'react-router-dom';

class App extends React.Component {

    gotocart() {
        window.location.href = "/cart";
    }
 
    render() {
        return (

            <>
                <header className="w-100 h-100 bg-dark px-4 my-shadow d-flex justify-content-between align-items-center">
                    <h3 className="text-light fs-2 fw-bold fst-italic">
                        <span> <a className="text-light" href=".">Shop Watches</a></span>
                    </h3>

                    <div className="btn-toolbar" role="toolbar">

                        <div className="btn-group btn-group-lg me-2" role="group">
                            <button onClick={this.gotocart} className="btn btn-outline-light">
                                Cart 
                            </button>
                        </div>
                    </div>
                </header>
                <main>
                    <Routes>
                        <Route path="/" element={<Home />} />
                        <Route path="/home" element={<Home />} />
                        <Route path="/cart" element={<Cart />} />
                        <Route path="/checkout" element={<Checkout />} />
                    </Routes>
                </main>
            </>
        )
    }
}
export default App;