import { useDeliveries } from "../contexts/DeliveryContext";

function DeliveryCard() {
	const { newDelivery } = useDeliveries();

	return (
		<div className="col-3 d-flex justify-content-center align-self-start">
			<div className="card" style={{ height: "225px", overflow: "hidden" }}>
				<div className="card-body" style={{ overflowY: "auto" }}>
					<h5 className="card-title">Delivery</h5>
					<p className="card-text">Vehicle Type: {newDelivery?.vehicleType}</p>
					<p className="card-text">Max Weight: {newDelivery?.maxWeight} kgs</p>
					<p className="card-text">
						Current Weight: {newDelivery?.currentWeight} kgs
					</p>
					<p className="card-text text-truncate" style={{ maxWidth: "100%" }}>
						Txn IDs: {newDelivery?.txnIDs.join(", ")}
					</p>
				</div>
			</div>
		</div>
	);
}

export default DeliveryCard;
