
import { Modal, Button } from 'react-bootstrap'
import React, {Component, useEffect, useState} from "react";
import { useNavigate } from 'react-router-dom';
import AuthUser from "../../Services/AuthUser";
import '../../App.css';


export default function EventTypeEditModal({id}) {


  const [description, setDescription] = useState('');
  const [pictureLink, setPictureLink] = useState('');

  const navigate = useNavigate();
  const { http,  getToken } = AuthUser();

  const[eventTypes, setEventTypes] = useState([]);

  const fetchEventType = () =>{
      console.log({id});
      http.get(`/eventType/${id}`)
      .then((res) =>{
          setEventTypes(res.data);
          setDescription(res.data.description);
          setPictureLink(res.data.pictureLink);
          console.log(res.data.name);
      }).catch(() =>{
          alert("Error with fetching eventType");
      })
  };

  const edit = async () => {
      const data = {
          description: description,
          pictureLink: pictureLink
      }
      

      http.put(`eventType/${id}`, data, {
          headers: {
              "Content-type": "application/json",
              "Authorization": `Bearer ${getToken()}`
          },
      }).then((res) => {
          handleClose();
          navigate('/home');
          window.location.reload();
          console.log(res.data);
      }).catch((error) => {
          alert("Cant edit event type");
          navigate('/home');
      })
  }

    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

  return (
    <>
    <Button variant="success" onClick={() => { handleShow(); fetchEventType();}}>
    Edit
    </Button>
  <Modal show = {show} onHide={handleClose} backdrop="static" keyboard={false}>
    <Modal.Header closeButton onClick={handleClose}>
      <Modal.Title>Edit Event Type</Modal.Title>
    </Modal.Header>
    <Modal.Body>
    
        <br></br>
        <h2>Edit Event Type</h2>
        <br></br>
        <label>Description</label>
        <input type = "textarea" defaultValue={description} onChange={(e)=>setDescription(e.target.value)} className="form-control" placeholder="Description"/>
        <label>Link to picture</label>
        <input type = "textarea" defaultValue={pictureLink} onChange={(e)=>setPictureLink(e.target.value)} className="form-control" placeholder="Link"/>
        <br></br>
        <button onClick={edit} className="btn btn-primary">Edit Event Type</button>
    
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


