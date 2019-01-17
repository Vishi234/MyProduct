var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var LoginBox = (function (_super) {
    __extends(LoginBox, _super);
    function LoginBox() {
        _super.apply(this, arguments);
    }
    LoginBox.prototype.render = function () {
        return (<div className="login-base slideInDown">
            <div className="login-form cstform">
                <p>Don't you have a account? <a href="javascript:void(0)">Sign up</a></p>
                <div className="form-group">
                <label for="email">Email address</label>
                <input type="text" name="email" className="form-control col-md-12"/>
                </div>
                <div className="form-group">
                <label for="password">Password</label>
                <input type="password" name="password" className="form-control col-md-12"/>
                </div>
                <div className="form-group">
                    <label className="check pull-left">
                        <span>Remeber me</span>
                        <input type="checkbox" name="remember"/>
                        <span className="checkmark"></span>
                    </label>
                    <a href="javascript:void(0)" className="frgtPass pull-right">Forgot my password</a>
                </div>
                <div className="form-group">
                    <button className="btn btn-success btnDisable col-md-12">Login</button>
                </div>
                <div className="orLabelBase">
                    <span className="orLabel">OR Login Using</span>
                    <hr />
                </div>
                <div className="form-group">
                    <ul className="social-login">
                        <li><a href="javascript:void(0)"><i className="fab fa-google-plus-square"></i></a></li>
                        <li><a href="javascript:void(0)"><i className="fab fa-facebook-square"></i></a></li>
                        <li><a href="javascript:void(0)"><i className="fab fa-twitter-square"></i></a></li>
                    </ul>
                </div>
            </div>
        </div>);
    };
    return LoginBox;
}(React.Component));
ReactDOM.render(<LoginBox />, document.getElementById('content'));
