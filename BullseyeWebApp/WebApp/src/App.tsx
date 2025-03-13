// Contexts
import { OrdersProvider } from "./contexts/OrdersContext.tsx";
import { VehicleProvider } from "./contexts/VehicleContext.tsx";
import { DeliveryProvider } from "./contexts/DeliveryContext.tsx";

// Components
import Orders from "./components/OrdersDGV.tsx";
import ShowButton from "./components/AllOrdersBtn.tsx";
import Modal from "./components/VehicleModal.tsx";
import TruckDisplay from "./components/TruckCards.tsx";
import ConfirmButton from "./components/ConfirmOrderBtn.tsx";
import DeliveryCard from "./components/DeliveryCard.tsx";
import Notes from "./components/Notes.tsx";
import DatePicker from "./components/DatePicker.tsx";

// Other
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/js/bootstrap.bundle.min.js";
import React from "react";
import { useState } from "react";

const App: React.FC = () => {
	const [showModal, setShowModal] = React.useState(false);

	const [notes, setNotes] = useState(""); // Declared top level sent to ConfirmButton and Notes for use

	return (
		<OrdersProvider>
			<VehicleProvider>
				<DeliveryProvider>
					<div className="container-fluid bg-light pb-5 min-vh-100">
						<div className="row bg-primary text-white p-2 text-center mb-4">
							<h1>Orders</h1>
						</div>
						<div className="row">
							<div className="d-flex justify-content-center col">
								<Orders />
							</div>
							<DeliveryCard />
						</div>
						<ConfirmButton notes={notes} setNotes={setNotes} />
						<div className="row d-flex justify-content-center mt-4">
							<ShowButton />
							<div className="col d-flex justify-content-center">
								<button
									className="btn btn-secondary"
									onClick={() => setShowModal(true)}>
									Available Vehicles
								</button>

								{showModal && (
									<Modal
										show={showModal}
										onClose={() => setShowModal(false)}
										title="Delivery Trucks">
										<TruckDisplay />
									</Modal>
								)}
							</div>
						</div>
						<div className="row p-2 text-center mt-4">
							<DatePicker />
							<Notes notes={notes} setNotes={setNotes} />
						</div>
					</div>
				</DeliveryProvider>
			</VehicleProvider>
		</OrdersProvider>
	);
};

export default App;
