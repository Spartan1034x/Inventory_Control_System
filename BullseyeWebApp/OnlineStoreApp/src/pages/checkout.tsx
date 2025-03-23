import { useInventory } from "../contexts/InventoryContext";
import { TxnDTO, postTxn } from "../DatabaseOps";
import { useState } from "react";
import { useNavigate } from "react-router-dom";

function Checkout() {
	const { cart, setCart } = useInventory();
	const navigate = useNavigate();

	// States for user inputs
	const [name, setName] = useState(""); // Log checked working
	const [email, setEmail] = useState("");
	const [phone, setPhone] = useState("");

	// Function to remove selected item from cart
	const removeItem = (itemID: number) => {
		setCart(cart.filter((item) => item.itemID !== itemID));
	};

	const total = cart.reduce((acc, item) => acc + item.price * item.quantity, 0); // Calculate total price
	const grandTotal = total * 1.15; // Calculate grand total

	const checkout = async () => {
		if (cart.length === 0) {
			alert("Cart is empty");
			return;
		}

		if (!name || !email || !phone) {
			alert("Please fill out all fields");
			return;
		}

		const notes = `Name: ${name}, Email: ${email}, Phone: ${phone}`; // Notes for transaction

		const txn: TxnDTO = {
			siteIdTo: cart[0].siteID, // All items from same store
			items: cart.map((item) => ({
				itemId: item.itemID,
				quantity: item.quantity,
			})),
			notes: notes,
		};
		console.log("Object Sent", txn);

		postTxn(txn); // Post transaction
		setCart([]); // Clear cart

		alert("Order Placed!");

		// Navigate to home page
		navigate("/");
	};

	return (
		<div
			className="pt-3"
			style={{
				background: "linear-gradient(90deg, #00C9FF 0%, #92FE9D 100%)",
			}}>
			<div className="container">
				<div className="row fw-bold bg-info-subtle py-2 border-bottom">
					<div className="col-5">Name</div>
					<div className="col-2">Price</div>
					<div className="col-2">Quantity</div>
					<div className="col-2">Remove</div>
				</div>

				{cart.map((item) => (
					<div
						className="row py-2 border-bottom"
						key={item.itemID}
						style={{ backgroundColor: "#dff2f1" }}>
						<div className="col-5">{item.name}</div>
						<div className="col-2">${item.price.toFixed(2)}</div>
						<div className="col-2">{item.quantity}</div>
						<div className="col-2">
							<a
								className="btn btn-danger"
								role="button"
								onClick={() => {
									removeItem(item.itemID);
								}}>
								Remove
							</a>
						</div>
					</div>
				))}

				<div className="row">
					<div className="d-flex bg-secondary py-3 justify-content-around text-white">
						<div>Sub Total: ${total.toFixed(2)}</div>
						<div>Grand Total: ${grandTotal.toFixed(2)}</div>
					</div>
				</div>

				<div className="pt-5">
					<form
						className="bg-info-subtle p-3 "
						style={{ width: "50%", margin: "auto" }}>
						<h4 className="text-center">Customer Information</h4>
						<div className="form-group p-2">
							<div className="pb-3">
								<label htmlFor="name">Full Name</label>
								<input
									type="text"
									className="form-control"
									id="name"
									value={name}
									onChange={(e) => {
										setName(e.target.value);
									}}
								/>
							</div>
							<div className="pb-3">
								<label htmlFor="email">Email</label>
								<input
									type="email"
									className="form-control"
									id="email"
									value={email}
									onChange={(e) => {
										setEmail(e.target.value);
									}}
								/>
							</div>
							<div className="pb-3">
								<label htmlFor="phone">Phone</label>
								<input
									type="tel"
									className="form-control"
									id="phone"
									value={phone}
									onChange={(e) => {
										setPhone(e.target.value);
									}}
								/>
							</div>
						</div>
					</form>
				</div>

				<div className="d-flex justify-content-center pt-5">
					<p
						className="btn btn-primary"
						role="button"
						onClick={() => {
							checkout();
						}}>
						Checkout
					</p>
				</div>
			</div>
		</div>
	);
}

export default Checkout;
