import Orders from "./components/OrdersDGV.tsx";
import { OrdersProvider } from "./contexts/OrdersContext.tsx";
import ShowButton from "./components/ShowAllOrders.tsx";

function App() {
	return (
		<OrdersProvider>
			<div className="container-fluid bg-light pb-5">
				<div className="row bg-primary text-white p-2 text-center mb-4">
					<h1>Orders</h1>
				</div>
				<div className="row">
					<div className="d-flex justify-content-center">
						<Orders />
					</div>
				</div>
				<div className="row d-flex justify-content-center mt-4">
					<ShowButton />
				</div>
			</div>
		</OrdersProvider>
	);
}

export default App;
