import React, { Component } from 'react';
import { Redirect } from 'react-router-dom';

export class Login extends Component {

    constructor(props) {
        super(props);
        this.state = { UserName: "", Password: "" };

        this.EmailHandleChange = this.EmailHandleChange.bind(this);
        this.PasswordHandleChange = this.PasswordHandleChange.bind(this);
        this.LoginClick = this.LoginClick.bind(this);
    }

    EmailHandleChange(event) {
        this.setState({ UserName: event.target.value });
    }

    PasswordHandleChange(event) {
        this.setState({ Password: event.target.value });
    }

    LoginClick(event) {

        if (this.state.UserName == "admin@dmsswe.com" && this.state.Password == "admin") {

            window.location.href = "/Home";

        }
        else {
            alert("Invalid UserName or Password.");
        }

        event.preventDefault();
    }

    render() {
        return (
            <form>
            <div className="hold-transition login-page">
                    <div className="login-box">
                        {/* /.login-logo */}
                        <div className="card card-outline card-primary">
                            <div className="card-header text-center">
                                <div  className="h1">
                                <b>DMS-</b>LMS
                                </div>
                            </div>
                            <div className="card-body">
                                <p className="login-box-msg">Sign in to start your session</p>
                                <div className="input-group mb-3">
                                    <input type="email" className="form-control" placeholder="Email" value={this.state.UserName} onChange={this.EmailHandleChange} />
                                        <div className="input-group-append">
                                            <div className="input-group-text">
                                                <span className="fas fa-envelope" />
                                            </div>
                                        </div>
                                    </div>
                                    <div className="input-group mb-3">
                                        <input
                                        type="password"
                                        className="form-control"
                                        placeholder="Password"
                                        value={this.state.Password}
                                        onChange={this.PasswordHandleChange}
                                        />
                                        <div className="input-group-append">
                                            <div className="input-group-text">
                                                <span className="fas fa-lock" />
                                            </div>
                                        </div>
                                    </div>
                                    <div className="row">
                                        <div className="col-8">
                                            <div className="icheck-primary">
                                                <input type="checkbox" id="remember" />
                                                <label htmlFor="remember">Remember Me</label>
                                            </div>
                                        </div>
                                        {/* /.col */}
                                    <div className="col-4">
                                    <button className="btn btn-primary btn-block" onClick={this.LoginClick} >
                                                Sign In
                                            </button>
                                        </div>
                                        {/* /.col */}
                                    </div>
                           
                                {/* /.social-auth-links */}
                                <p className="mb-1">
                                    <a href="forgot-password.html">I forgot my password</a>
                                </p>
                                <p className="mb-0">
                                    <a href="register.html" className="text-center">
                                        Register a new membership
                                    </a>
                                </p>
                            </div>
                            {/* /.card-body */}
                        </div>
                        {/* /.card */}
                    </div>
                    {/* /.login-box */}

             
                </div>
            </form>
        );
    }
}
