
import { Modal, Button } from 'react-bootstrap'
import React, {Component, useEffect, useState} from "react";
import { useNavigate } from 'react-router-dom';
import AuthUser from "../../Services/AuthUser";
import '../../App.css';


export default function CommentEditModal({id1, id2, id3}) {


  const [content, setContent] = useState('');
  const [comment, setComment] = useState([]);

  const navigate = useNavigate();
  const { http,  getToken } = AuthUser();


  const fetchEvent = () =>{
    http.get(`eventType/${id1}/event/${id2}/comments/${id3}`)
    .then((res) =>{
        setComment(res.data);
        setContent(res.data.content);
    }).catch(() =>{
        alert("Error with event");
    })
};

const edit = async () => {
  const data = {
      content: content,
  }

  http.put(`eventType/${id1}/event/${id2}/comments/${id3}`, data, {
      headers: {
          "Content-type": "application/json",
          "Authorization": `Bearer ${getToken()}`
      },
  }).then((res) => {
      handleClose();
      navigate(`/home/eventType/${id1}/event/${id2}/comments`);
      window.location.reload();
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
    <Button variant="success" onClick={() => { handleShow(); fetchEvent();}}>
    Edit
    </Button>
  <Modal show = {show} onHide={handleClose}  backdrop="static" keyboard={false}>
    <Modal.Header closeButton onClick={handleClose}>
      <Modal.Title>Edit comment</Modal.Title>
    </Modal.Header>
    <Modal.Body>
    <br></br>
            <h2>Edit Comment</h2>
            <label>Description</label>
            <input type = "textarea" defaultValue={content} onChange={(e)=>setContent(e.target.value)} className="form-control" placeholder="Description"/>
            <br></br>
            <br></br>
            <button onClick={edit} className="btn btn-primary">Edit</button>
    
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


