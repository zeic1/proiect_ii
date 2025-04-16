import React, { useState } from "react";
import "./PharmacyAppUI.css";

const Card = ({ children }) => (
    <div className="card">{children}</div>
);
const CardContent = ({ children }) => <div>{children}</div>;
const Button = ({ children, ...props }) => (
    <button className="btn" {...props}>
        {children}
    </button>
);
const Input = (props) => (
    <input className="input" {...props} />
);

export default function PharmacyAppUI() {
    const [isLoggedIn, setIsLoggedIn] = useState(false);
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [email, setEmail] = useState("");
    const [role, setRole] = useState(null);
    const [isRegistering, setIsRegistering] = useState(false);

    const validateEmail = (email) => {
        const pattern = /^[^\s@]+@(gmail\.com|yahoo\.com|hotmail\.com)$/;
        return pattern.test(email);
    };

    const handleLogin = () => {
        if (!username || !password) {
            alert("Please enter username and password.");
            return;
        }

        if (username === "admin" && password === "admin") {
            setRole("admin");
            setIsLoggedIn(true);
        } else {
            const foundPharmacist = username.startsWith("pharmacist");
            const foundCustomer = username.startsWith("user");

            if (foundPharmacist) {
                setRole("pharmacist");
                setIsLoggedIn(true);
            } else if (foundCustomer) {
                setRole("customer");
                setIsLoggedIn(true);
            } else {
                alert("Invalid credentials.");
            }
        }
    };

    const handleRegister = () => {
        if (!email || !username || !password) {
            alert("Please fill in all fields.");
            return;
        }
        if (!validateEmail(email)) {
            alert("Please enter a valid email (gmail.com, yahoo.com, hotmail.com).");
            return;
        }
        setRole("customer");
        setIsLoggedIn(true);
    };

    if (!isLoggedIn) {
        return (
            <div className="container">
                <h1 className="title">{isRegistering ? "Register as Customer" : "Login"}</h1>
                {isRegistering && (
                    <Input
                        placeholder="Email (e.g. yourname@gmail.com)"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                    />
                )}
                <Input
                    placeholder="Username"
                    value={username}
                    onChange={(e) => setUsername(e.target.value)}
                />
                <Input
                    type="password"
                    placeholder="Password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                />
                {isRegistering ? (
                    <Button onClick={handleRegister}>Register</Button>
                ) : (
                    <Button onClick={handleLogin}>Login</Button>
                )}
                <Button className="link-btn" onClick={() => setIsRegistering(!isRegistering)}>
                    {isRegistering ? "Back to Login" : "Create a Customer Account"}
                </Button>
            </div>
        );
    }

    return (
        <div className="container">
            <h1 className="title">Pharmacy Management System</h1>

            {role === "customer" && (
                <Card>
                    <CardContent>
                        <h2 className="subtitle">Customer Dashboard</h2>
                        <Button>Upload Doctor Letter</Button>
                        <Button>Update Doctor Letter</Button>
                        <Button>Browse Medications</Button>
                        <Button>Place Orders</Button>
                        <Button>Track Orders</Button>
                    </CardContent>
                </Card>
            )}

            {role === "pharmacist" && (
                <Card>
                    <CardContent>
                        <h2 className="subtitle">Pharmacist Dashboard</h2>
                        <Button>Validate Prescription</Button>
                        <Button>Update Order Status</Button>
                        <Button>View Order History</Button>
                        <Button>Manage Inventory</Button>
                        <Button>Transfer Stock</Button>
                    </CardContent>
                </Card>
            )}

            {role === "admin" && (
                <Card>
                    <CardContent>
                        <h2 className="subtitle">Admin Dashboard</h2>
                        <Button>Create Pharmacist Account</Button>
                        <Button>Set Permissions</Button>
                        <Button>Maintain Database</Button>
                        <Button>Monitor System Logs</Button>
                        <Button>Perform Backups</Button>
                    </CardContent>
                </Card>
            )}
        </div>
    );
}
