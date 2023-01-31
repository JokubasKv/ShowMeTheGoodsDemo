
import { Modal, Button } from 'react-bootstrap'
import React, {Component, useEffect, useState} from "react";
import { useNavigate } from 'react-router-dom';
import AuthUser from "../../Services/AuthUser";
import '../../App.css';


export default function EventEditModal({id1, id2}) {


  const [Name, setName] = useState('');
  const [Description, setDescription] = useState('');
  const [Place, setPlace] = useState('');
  const [Price, setPrice] = useState('');
  const [Date, setDate] = useState('');
  const [pictureLink, setPictureLink] = useState('');
  const [Event, setEvent] = useState("");

  const navigate = useNavigate();
  const { http,  getToken } = AuthUser();


  const fetchEvent = () =>{
    http.get(`/eventType/${id1}/event/${id2}`)
    .then((res) =>{
        setEvent(res.data);
        setName(res.data.name);
        setDescription(res.data.description);
        setPrice(res.data.price);
        setPlace(res.data.place);
        setPictureLink(res.data.pictureLink);
        setDate(res.data.eventDate);


        console.log("Name of event ",res.data.name);
    }).catch(() =>{
        alert("Error with event");
    })
};

const edit = async () => {
  console.log(getToken());
  console.log("description", Description);

  const data = {
      Name: Name,
      Description: Description,
      Place: Place,
      Price: Price,
      eventDate: Date,
      pictureLink:pictureLink
  }
  
  console.log(data);
  console.log(getToken());
  http.put(`eventType/${id1}/event/${id2}`, data, {
      headers: {
          "Content-type": "application/json",
          "Authorization": `Bearer ${getToken()}`
      },
  }).then((res) => {
      handleClose();
      navigate(`/home/api/eventType/${id1}/event`);
      window.location.reload();
      console.log(res.data);
  }).catch((error) => {
      alert("Cant edit event");
      navigate(`/home/api/eventType/${id1}/event`);
  })
}

    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

  return (
    <>
    <Button variant="success" onClick={() => { handleShow(); fetchEvent();}}>
    Edit
    </Button>
  <Modal show = {show} onHide={handleClose}  backdrop="static" keyboard={false}>
    <Modal.Header closeButton onClick={handleClose}>
      <Modal.Title>Edit Event Type</Modal.Title>
    </Modal.Header>
    <Modal.Body>
    <br></br>
            <h2>Edit Event</h2>
            <br></br>
            <label>Name</label>
            <input type = "text" defaultValue={Name} onChange={(e)=>setName(e.target.value)} className="form-control" placeholder="Name"/>
            <br></br>
            <label>Description</label>
            <input type = "textarea" defaultValue={Description} onChange={(e)=>setDescription(e.target.value)} className="form-control" placeholder="Description"/>
            <br></br>
            <label>Place</label>
            <input type = "textarea" defaultValue={Place} onChange={(e)=>setPlace(e.target.value)} className="form-control" placeholder="Place"/>
            <br></br>
            <label>Price</label>
            <input type = "number" defaultValue={Price} onChange={(e)=>setPrice(e.target.value)} className="form-control" placeholder="Price"/>
            <br></br>
            <label>When is event</label>
            <input type = "date" defaultValue={Date} onChange={(e)=>setDate(e.target.value)} className="form-control" placeholder="Link"/>
            <br></br>
            <label>Link to picture</label>
            <input type = "textarea" defaultValue={pictureLink} onChange={(e)=>setPictureLink(e.target.value)} className="form-control" placeholder="Link"/>
            <br></br>
            <button onClick={edit} className="btn btn-primary">Edit event</button>
    
    </Modal.Body>
    <Modal.Footer>
      <Button variant="danger" onClick={handleClose}>
        Close
      </Button>
    </Modal.Footer>
  </Modal>
  </>
  )
}


