import React, { useState } from "react";
import Constants from "./utilities/Constants";
import DrawingCreateForm from "./Components/DrawingCreateForm";
import DrawingUpdateForm from "./Components/DrawingUpdateForm";

export default function App() {
  const [drawings, setDrawings] = useState([]);
  const [showingCreateNewDrawingForm, setShowingCreateNewDrawingForm] = useState(false);
  const [drawingCurrentlyBeingUpdated, setDrawingCurrentlyBeingUpdated] = useState(null);

  function getDrawings() {
    const url = Constants.API_URL_GET_ALL_DRAWINGS;

    fetch(url, {
      method: 'GET'
    })
      .then(response => response.json())
      .then(drawingFromServer => {
        console.log(drawingFromServer);
        setDrawings(drawingFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      })
  }

  function deleteDrawing(drawingId){
    const url = Constants.API_URL_DELETE_DRAWING + `/${drawingId}`;

    alert(`we are here`);

    fetch(url, {
      method: 'DELETE'
    })
      .then(response => response.json())
      .then(drawingFromServer => {
        console.log(drawingFromServer);
        onDrawingDeleted(drawingId);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      })
  }

  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          {(showingCreateNewDrawingForm === false && drawingCurrentlyBeingUpdated === null) && (
            <div>
              <h1> ASP.NET Core React Tutorial</h1>

              <div className="mt-5">
                <button onClick={getDrawings} className="btn btn-dark btn-lg w-100">
                  Get Drawings from server
                </button>
                <button onClick={() => setShowingCreateNewDrawingForm(true)} className="btn btn-secondary btn-lg w-100 mt-4">
                  Create New Drawing
                </button>
              </div>
            </div>
          )}

          {(drawings.length > 0
            && showingCreateNewDrawingForm === false
            && drawingCurrentlyBeingUpdated === null) && renderDrawingsTable()}

          {showingCreateNewDrawingForm && <DrawingCreateForm onDrawingCreated={onDrawingCreated} />}

          {drawingCurrentlyBeingUpdated !== null
            && <DrawingUpdateForm drawing={drawingCurrentlyBeingUpdated}
              onDrawingUpdated={onDrawingUpdated} />}
        </div>
      </div>
    </div>
  );

  function renderDrawingsTable() {
    return (
      <div className="table-responsive mt-5">
        <table className="table table-bordered border-dark">
          <thead>
            <tr>
              <th scope="col">Id</th>
              <th scope="col">Text</th>
              <th scope="col">Points</th>
              <th scope="col">DescriptionPhotoLink</th>
              <th scope="col">DrawingPhotoLink</th>
              <th scope="col">CRUD Operations</th>
            </tr>
          </thead>
          <tbody>
            {drawings.map((drawing) => (
              <tr>
                <td scope="row">{drawing.id}</td>
                <td>{drawing.description.text}</td>
                <td>{drawing.description.points}</td>
                <td>{drawing.description.descriptionPhotoLink}</td>
                <td>{drawing.drawingPhotoLink}</td>
                <td>
                  <button onClick={() => setDrawingCurrentlyBeingUpdated(drawing)} className="btn btn-dark btn-lg mx-3 my-3">Update</button>
                  <button onClick={() => {
                    if (window.confirm(`Are you sure you want to delete the drawing with id:${drawing.id}?`))
                    {
                      deleteDrawing(drawing.id);
                    }
                  }} className="btn btn-seconadry btn-lg">Delete</button>
                </td>
              </tr>))}
          </tbody>
        </table>

        <button onClick={() => setDrawings([])} className="btn btn-dark btn-lf w-100">
          Empty React drawings array
        </button>
      </div>
    )
  }

  function onDrawingCreated(createdDrawing) {
    setShowingCreateNewDrawingForm(false);

    if (createdDrawing !== null) {
      alert(`Drawing is successfully created`);
    }
    else
    {
      alert(`Drawing isn't created`);
    }
    
    getDrawings();
  }

  function onDrawingUpdated(updatedDrawing) {
    setDrawingCurrentlyBeingUpdated(null);

    if (updatedDrawing === null) {
      return;
    }

    let drawingsCopy = [...drawings];

    const index = drawingsCopy.findIndex((drawingsCopyDrawing, currentIndex) => {
      if (drawingsCopyDrawing.id === updatedDrawing.id) {
        return true;
      }
    });

    if (index !== -1) {
      drawingsCopy[index] = updatedDrawing;
    }

    setDrawings(drawingsCopy);

    alert(`Drawing successfully updated`);
  }
  
  function onDrawingDeleted(deletedDrawingId) {
    let drawingsCopy = [...drawings];

    const index = drawingsCopy.findIndex((drawingsCopyDrawing, currentIndex) => {
      if (drawingsCopyDrawing.id === deletedDrawingId) {
        return true;
      }
    });

    if (index !== -1) {
      drawingsCopy.splice(index, 1);
    }

    setDrawings(drawingsCopy);

    alert(`Drawing successfully deleted`);
  }
}
