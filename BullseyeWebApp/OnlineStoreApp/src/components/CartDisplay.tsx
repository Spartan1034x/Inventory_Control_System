import { useInventory } from "../contexts/InventoryContext";

function CartContent() {
	const { cart, setCart } = useInventory();

	const total = cart.reduce((acc, item) => acc + item.price * item.quantity, 0); // Calculate total price
	const items = cart.reduce((acc, item) => acc + item.quantity, 0); // Calculate total items

	// Function to remove selected item from cart
	const removeItem = (itemID: number) => {
		setCart(cart.filter((item) => item.itemID !== itemID));
	};

	return (
		<div>
			<div className="row fw-bold bg-light py-2 border-bottom">
				<div className="col-5">Name</div>
				<div className="col-2">Price</div>
				<div className="col-2">Quantity</div>
				<div className="col-2">Remove</div>
			</div>

			{cart.map((item) => (
				<div className="row py-2 border-bottom" key={item.itemID}>
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

			<p className="d-flex justify-content-between mt-3">
				<span>Sub Total: ${total.toFixed(2)}</span>
				<span>Items: {items}</span>
			</p>
		</div>
	);
}

export default CartContent;
