import { useEffect, useState } from "react";
import { useInventory } from "../../contexts/InventoryContext";

type Category = {
	name: string;
};

function CategoryDropdown() {
	const { inventory, filteredInventory, setFilteredInventory } = useInventory();
	const [category, setCategory] = useState<Category[]>([]);
	const [selectedCategory, setSelectedCategory] = useState("All"); // Initially set to all to allow all to populate
	const [inStockOnly, setInStockOnly] = useState(true); // State for in-stock filter

	useEffect(() => {
		console.log(inventory);
	}, [inventory]);

	const items = filteredInventory.length;

	// Get unique categories from inventory everytime inventory changes
	useEffect(() => {
		const uniqueCategories = [
			...new Set(inventory.map((item) => item.category)),
		];
		const categoryObjects = uniqueCategories.map((cat) => ({ name: cat }));
		setCategory(categoryObjects);
	}, [inventory]); // Run this effect only when `inventory` changes

	// Effect that runs when selected inventory changes, set inventory to selected category
	useEffect(() => {
		let filtered = inventory;
		if (selectedCategory !== "All") {
			filtered = filtered.filter((item) => item.category === selectedCategory);
		}
		if (inStockOnly) {
			filtered = filtered.filter((item) => item.quantity > 0);
		}
		setFilteredInventory(filtered);
	}, [selectedCategory, inventory, inStockOnly, setFilteredInventory]); // Run this effect only when `selectedCategory` or `inStockOnly` changes

	const filterPrice = (price: string) => {
		let sortedInventory = [...filteredInventory];
		if (price === "High") {
			// Sort inventory by price high to low
			sortedInventory.sort((a, b) => b.price - a.price);
		}
		if (price === "Low") {
			// Sort inventory by price low to high
			sortedInventory.sort((a, b) => a.price - b.price);
		}
		if (price === "All") {
			// Set inventory to all items
			sortedInventory = inventory;
		}
		if (inStockOnly) {
			sortedInventory = sortedInventory.filter((item) => item.quantity > 0);
		}
		setFilteredInventory(sortedInventory);
	};

	return (
		<div className="container py-3">
			<div className="d-flex justify-content-between">
				<div className="text-center fs-4">
					Category:{" "}
					<span className="fw-bold">
						{selectedCategory} ({items})
					</span>
				</div>
				<div className="d-flex">
					<div className="dropdown me-4">
						<button
							className="btn btn-secondary dropdown-toggle"
							type="button"
							data-bs-toggle="dropdown"
							aria-expanded="false">
							Category
						</button>
						<ul className="dropdown-menu">
							<li style={{ cursor: "pointer" }}>
								<a
									className="dropdown-item"
									onClick={() => setSelectedCategory("All")}>
									All
								</a>
							</li>
							{category.map((cat) => (
								<li key={cat.name} style={{ cursor: "pointer" }}>
									<a
										className="dropdown-item"
										onClick={() => setSelectedCategory(cat.name)}>
										{cat.name}
									</a>
								</li>
							))}
						</ul>
					</div>
					<div className="dropdown me-4">
						<button
							className="btn btn-secondary dropdown-toggle"
							type="button"
							data-bs-toggle="dropdown"
							aria-expanded="false">
							Price
						</button>
						<ul className="dropdown-menu">
							<li style={{ cursor: "pointer" }}>
								<a
									className="dropdown-item"
									onClick={() => filterPrice("High")}>
									High
								</a>
							</li>
							<li style={{ cursor: "pointer" }}>
								<a className="dropdown-item" onClick={() => filterPrice("Low")}>
									Low
								</a>
							</li>
							<li style={{ cursor: "pointer" }}>
								<a className="dropdown-item" onClick={() => filterPrice("All")}>
									All
								</a>
							</li>
						</ul>
					</div>
					<div className="form-check">
						<input
							className="form-check-input"
							type="checkbox"
							checked={inStockOnly}
							onChange={() => setInStockOnly(!inStockOnly)}
							id="inStockOnly"
						/>
						<label className="form-check-label" htmlFor="inStockOnly">
							In Stock Only
						</label>
					</div>
				</div>
			</div>
		</div>
	);
}

export default CategoryDropdown;
