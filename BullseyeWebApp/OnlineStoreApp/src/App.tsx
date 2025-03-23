// Librarys
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/js/bootstrap.bundle.min";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

// Components
import NavBar from "./components/navbar";

// Pages
import Index from "./pages/index";
import Store from "./pages/store";
import Checkout from "./pages/checkout";
import Profile from "./pages/profile";

// Contexts (Wrap in main.tsx in future)
import { SiteProvider } from "./contexts/SiteContext";
import { InventoryProvider } from "./contexts/InventoryContext";

const App: React.FC = () => {
	//const [canCheckout, setCanCheckout] = useState<boolean>(false); // State to store the sites

	return (
		<Router>
			<SiteProvider>
				<InventoryProvider>
					<NavBar />

					<Routes>
						<Route path="/" element={<Index />} />
						<Route path="/store" element={<Store />} />
						<Route path="/checkout" element={<Checkout />} />
						<Route path="/profile" element={<Profile />} />
					</Routes>
				</InventoryProvider>
			</SiteProvider>
		</Router>
	);
};

export default App;
