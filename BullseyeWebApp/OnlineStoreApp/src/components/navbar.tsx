import { Link } from "react-router-dom";
import { useSite } from "../contexts/SiteContext";
import { useInventory } from "../contexts/InventoryContext";
import Modal from "./CartModal";
import CartContent from "./CartDisplay";
import React from "react";
import { useState } from "react";

function NavBar() {
	const { sites, selectedSite, setSelectedSite } = useSite();
	const { cart, inventory, filteredInventory, setFilteredInventory } =
		useInventory();
	const [showModal, setShowModal] = React.useState(false); // State to show the modal
	// const [filteredInventory, setFilteredInventory] = useState(inventory);

	const [search, setSearch] = useState("");

	/* useEffect(() => {
		console.log(search);
	}, [search]); */

	const executeSearch = (search: string) => {
		setSearch(search);

		if (search === "") {
			setFilteredInventory(inventory);
			return;
		}

		setFilteredInventory(
			filteredInventory.filter((item) =>
				item.name.toLowerCase().includes(search.toLowerCase())
			)
		);
	};

	return (
		<nav className="navbar navbar-expand-lg bg-body-tertiary">
			<div className="container-fluid">
				<a className="navbar-brand">
					<img
						src="/images/Logo.PNG"
						alt="Logo"
						width="30"
						height="24"
						className="d-inline-block align-text-top"
					/>
					Bullseye Online
				</a>
				<button
					className="navbar-toggler"
					type="button"
					data-bs-toggle="collapse"
					data-bs-target="#navbarSupportedContent"
					aria-controls="navbarSupportedContent"
					aria-expanded="false"
					aria-label="Toggle navigation">
					<span className="navbar-toggler-icon"></span>
				</button>
				<div className="collapse navbar-collapse" id="navbarSupportedContent">
					<ul className="navbar-nav me-auto mb-2 mb-lg-0">
						<li className="nav-item">
							<Link to="/" className="nav-link">
								Home
							</Link>
						</li>
						<li className="nav-item">
							<Link to="/store" className="nav-link">
								Store
							</Link>
						</li>
						<li className="nav-item dropdown">
							<a
								className="nav-link dropdown-toggle"
								role="button"
								data-bs-toggle="dropdown"
								aria-expanded="false">
								Locations
							</a>
							<ul className="dropdown-menu">
								{sites.map((site) => (
									<li key={site.id} style={{ cursor: "pointer" }}>
										<a
											className="dropdown-item"
											onClick={() => setSelectedSite(site)}>
											{site.name}
										</a>
									</li>
								))}
							</ul>
						</li>
						<li className="nav-item">
							{selectedSite ? (
								<a className="nav-link">Selected Site: {selectedSite.name}</a>
							) : (
								<a className="nav-link">No Site Selected</a>
							)}
						</li>
					</ul>
					<form
						className="d-flex justify-content-center align-items-center"
						role="search">
						<p>({cart.length})</p>
						<p
							className="me-4"
							style={{ cursor: "pointer" }}
							onClick={() => setShowModal(true)}>
							<img
								src="/images/cart.jpg"
								alt="cart"
								width="35px"
								height="35px"
							/>
						</p>
						{showModal && (
							<Modal
								show={showModal}
								onClose={() => setShowModal(false)}
								title="Cart">
								<CartContent />
							</Modal>
						)}
						<input
							className="form-control me-2"
							type="search"
							placeholder="Search Item"
							aria-label="Search"
							value={search}
							onChange={(e) => executeSearch(e.target.value)}
						/>
						<Link to="/profile" className="nav-link">
							<img
								src="/images/profile.jpg"
								alt="profile"
								width="35px"
								height="35px"
							/>
						</Link>
					</form>
				</div>
			</div>
		</nav>
	);
}

export default NavBar;
