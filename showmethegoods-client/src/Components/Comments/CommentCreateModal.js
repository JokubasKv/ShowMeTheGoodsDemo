
import { Modal, Button } from 'react-bootstrap'
import React, {Component, useEffect, useState} from "react";
import { useNavigate } from 'react-router-dom';
import AuthUser from "../../Services/AuthUser";
import '../../App.css';


export default function CommentCreateModal({id1, id2}) {


  const [content, setContent] = useState('');
  const [comment, setComment] = useState("");

  const navigate = useNavigate();
  const { http,  getToken } = AuthUser();

const create = async () => {
  const data = {
      content: content,
  }

  http.post(`eventType/${id1}/event/${id2}/comments`, data, {
      headers: {
          "Content-type": "application/json",
          "Authorization": `Bearer ${getToken()}`
      },
  }).then((res) => {
      handleClose();
      window.location.reload(false);  
      navigate(`/home/eventType/${id1}/event/${id2}/comments`);
      console.log(res.data);
  }).catch((error) => {
      alert("Cant edit event");  
      navigate(`/home/eventType/${id1}/event/${id2}/comments`);
  })
}

    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

  return (
    <>
    <Button variant="success" onClick={() => { handleShow();}}>
    Leave a comment
    </Button>
  <Modal show = {show} onHide={handleClose}  backdrop="static" keyboard={false}>
    <Modal.Header closeButton onClick={handleClose}>
      <Modal.Title>Leave a comment</Modal.Title>
    </Modal.Header>
    <Modal.Body>
    <br></br>
            <label>Comment</label>
            <input type = "textarea" defaultValue={content} onChange={(e)=>setContent(e.target.value)} className="form-control" placeholder="Description"/>
            <button onClick={create} className="btn btn-primary">Create</button>
    
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


