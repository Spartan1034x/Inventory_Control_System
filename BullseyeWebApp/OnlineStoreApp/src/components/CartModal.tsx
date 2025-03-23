import React from "react";
import { Link } from "react-router-dom";

interface ModalProps {
	show: boolean;
	onClose: () => void;
	title: String;
	children: React.ReactNode;
}

const Modal: React.FC<ModalProps> = ({ show, onClose, title, children }) => {
	return (
		<div
			className={`modal fade ${show ? "show d-block" : ""}`}
			tabIndex={-1}
			role="dialog"
			style={{ background: "rgba(0,0,0,0.5)" }}>
			<div className="modal-dialog" role="document">
				<div className="modal-content">
					<div className="modal-header">
						<h5 className="modal-title">{title}</h5>
						<button
							type="button"
							className="btn-close"
							onClick={onClose}></button>
					</div>
					<div className="modal-body">{children}</div>
					<div className="modal-footer d-flex justify-content-between">
						<Link to="/checkout" className="btn btn-primary" onClick={onClose}>
							Checkout
						</Link>

						<button
							type="button"
							className="btn btn-secondary"
							onClick={onClose}>
							Close
						</button>
					</div>
				</div>
			</div>
		</div>
	);
};

export default Modal;
