import { useEffect } from "react";

function Notes({
	notes,
	setNotes,
}: {
	notes: string;
	setNotes: (value: string) => void;
}) {
	const handleNotes = (e: React.ChangeEvent<HTMLTextAreaElement>) => {
		setNotes(e.target.value); // ✅ Update notes state in App.tsx
	};

	useEffect(() => {
		console.log(notes);
	}, [notes]);

	return (
		<div className="col-6 mx-auto">
			<label htmlFor="deliveryNotes" className="form-label">
				Notes
			</label>
			<textarea
				id="deliveryNotes"
				className="form-control"
				rows={5}
				placeholder="Delivery Notes..."
				onChange={handleNotes}
				value={notes}></textarea>
		</div>
	);
}

export default Notes;
