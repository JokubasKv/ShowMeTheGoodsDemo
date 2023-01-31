
import { Modal, Button } from 'react-bootstrap'
import React, {Component, useEffect, useState} from "react";
import { useNavigate } from 'react-router-dom';
import AuthUser from "../../Services/AuthUser";
import '../../App.css';


export default function EventTypeCreateModal() {


    const [name, setName] = useState('')
    const [description, setDescription] = useState('');
    const [pictureLink, setPictureLink] = useState('');

    const navigate = useNavigate();
    const { http, getUser, getToken } = AuthUser();


    const create = () => {
        //console.log("name", name);
        //console.log("description", description);

        const data = {
            name: name,
            description: description,
            pictureLink: pictureLink,
        }
        //console.log(data);
        //console.log(getToken());
        http.post('eventType/', data, {
            headers: {
                "Content-type": "application/json",
                "Authorization": `Bearer ${getToken()}`
            },
        }).then((res) => {
            handleClose();
            navigate('/home');
            console.log(res.data);
        }).catch((error) => {
            alert("Cant create event type");
            navigate('/home');
        })
    }

    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

  return (
    <>
    <Button variant="success" onClick={handleShow}>
    Create New Event Type
    </Button>
  <Modal show = {show} onHide={handleClose} backdrop="static" keyboard={false}>
    <Modal.Header closeButton onClick={handleClose}>
      <Modal.Title>Create New Event Type</Modal.Title>
    </Modal.Header>
    <Modal.Body>
    
        <br></br>
        <h2>Create new Event Type</h2>
        <br></br>
        <label>Name</label>
        <input type = "text" defaultValue={name} onChange={(e)=>setName(e.target.value)} className="form-control" placeholder="Name"/>
        <br></br>
        <label>Description</label>
        <input type = "textarea" defaultValue={description} onChange={(e)=>setDescription(e.target.value)} className="form-control" placeholder="Description"/>
        <label>Link to picture</label>
        <input type = "textarea" defaultValue={pictureLink} onChange={(e)=>setPictureLink(e.target.value)} className="form-control" placeholder="Link"/>
        <br></br>
        <button onClick={create} className="btn btn-primary">Create Event Type</button>
    
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


