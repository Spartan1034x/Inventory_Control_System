import { FixedSizeGrid as Grid } from "react-window";
import { useInventory, Inventory } from "../../contexts/InventoryContext";
import { useEffect, useRef, useState } from "react";

function StoreCards() {
	const { filteredInventory, cart, setCart } = useInventory();

	const parentRef = useRef<HTMLDivElement>(null); // Ref for the parent container
	const [dimensions, setDimensions] = useState({ width: 0, height: 0 }); // State for grid dimensions
	const [quantity, setQuantity] = useState<Record<number, number>>({}); // State storing itemID and quantity

	const handleQuantityChange = (itemID: number, quantity: number) => {
		setQuantity((prevQuantity) => ({ ...prevQuantity, [itemID]: quantity }));
	};

	const updateDimensions = () => {
		setDimensions({
			width: parentRef.current.offsetWidth,
			height: parentRef.current.offsetHeight,
		});
	};

	useEffect(() => {
		updateDimensions();
		window.addEventListener("resize", updateDimensions);
		return () => window.removeEventListener("resize", updateDimensions);
	}, []);

	const updateCart = (item: Inventory) => {
		// Find the items quantity from the quantity state
		const itemQuantity = quantity[item.itemID] || 1;

		const newItem = { ...item, quantity: itemQuantity };

		// If item already exists in the cart increment the quantity
		if (cart.some((cartItem) => cartItem.itemID === item.itemID)) {
			// Find the matching cart item and ensure added quantity and current quantity is less than or equal to stock
			const existingCartItem = cart.find((i) => i.itemID === item.itemID);
			if (item.quantity < itemQuantity + (existingCartItem?.quantity || 0)) {
				alert("Not enough stock available");
				return;
			}
			const updatedCart = cart.map((cartItem) =>
				cartItem.itemID === item.itemID
					? { ...cartItem, quantity: cartItem.quantity + itemQuantity }
					: cartItem
			);
			setCart(updatedCart);
			return;
		}
		// Add the item to the cart
		setCart((prevCart) => [...prevCart, newItem]);
	};

	return (
		<div
			ref={parentRef}
			style={{
				height: "100%",
				backgroundColor: "#dff2f1",
				width: "100%",
				padding: "0px",
				margin: "0px",
				border: "0px",
			}}>
			<Grid
				columnCount={3}
				columnWidth={dimensions.width / 3 - 5}
				rowHeight={500}
				height={dimensions.height}
				width={dimensions.width}
				rowCount={Math.ceil(filteredInventory.length / 3)}
				style={{ overflowX: "hidden" }}>
				{({ columnIndex, rowIndex, style }) => {
					const item = filteredInventory[rowIndex * 3 + columnIndex];
					const itemQuantity = quantity[item?.itemID] || 1;
					return (
						<div
							style={{
								...style,
								justifyContent: "center",
								alignItems: "center",
								border: "1px solid #ddd",
								padding: "10px",
								boxSizing: "border-box",
							}}>
							{item ? (
								<div
									className="card"
									style={{
										width: "100%",
										height: "100%",
										textAlign: "center",
									}}>
									<img
										src="/images/sports.jpg"
										className="card-img-top"
										style={{
											width: "100%",
											height: "200px",
											objectFit: "cover",
											borderRadius: "8px 8px 0 0",
										}}
										alt={item.name}
									/>
									<div className="card-body">
										<h5 className="card-title">{item.name}</h5>
										<p className="card-text">
											<strong>Description:</strong> {item.description}
										</p>
										<p className="card-text">
											<strong>Category:</strong> {item.category}
										</p>
										<p className="d-flex justify-content-between">
											<span>${item.price} </span>
											<span className="text-success">
												In Stock: {item.quantity}
											</span>
										</p>
										<p className="card-text">
											<span className="me-4">
												<input
													type="number"
													min={1}
													value={itemQuantity}
													max={item.quantity}
													onChange={(e) =>
														handleQuantityChange(item.itemID, +e.target.value)
													}
												/>
											</span>
											<span>
												<a
													className="btn btn-primary"
													role="button"
													onClick={() => {
														updateCart(item);
													}}>
													Add To Cart
												</a>
											</span>
										</p>
									</div>
								</div>
							) : (
								"Empty"
							)}
						</div>
					);
				}}
			</Grid>
		</div>
	);
}

export default StoreCards;
