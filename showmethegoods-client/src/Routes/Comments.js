import React, {Component, useEffect, useState} from "react";
import { variables } from "../Variables.js";
import { Navigate, useParams} from 'react-router-dom';
import AuthUser from "../Services/AuthUser";
import { Card } from "flowbite-react";
import { useNavigate } from 'react-router-dom';
import axios from "axios";
import CommentCreateModal from '../Components/Comments/CommentCreateModal'
import CommentEditModal from "../Components/Comments/CommentEditModal.js";


const AllComments = () =>{

    let { id1 } = useParams();
    let { id2 } = useParams();
    const navigate = useNavigate();
    const { http, getUser, getToken } = AuthUser();
    const [Comment, setPost] = useState("");
        
        const[comments, setComments] = useState([]);
    useEffect(() =>{
        fetchComments();
    } , []);

    const fetchComments = () =>{
        axios.get(`http://localhost:5001/api/eventType/${id1}/event/${id2}/comments`)
        .then((res) => {
            //console.log(res);
            setComments(res.data);
        })
        .catch((err) => {
            console.log(err);
        });
    };

    let CreateComment = async () =>{
        console.log("create new comment ");
        navigate(`comment`);
    }

    let EditComment = async (id) =>{
        console.log("edit comment with id", id);
        navigate(`comment/${id}`);
    }

    let RemoveComment = (id) =>{
        console.log("remove comment with id", id);
        http.delete(`/eventType/${id1}/event/${id2}/comments/${id}`,{
            headers:{
                "Content-type": "application/json",
                "Authorization": `Bearer ${getToken()}`
            },
        }).then((res) => {
            console.log(res.data);
            window.location.reload(false);  
            navigate(`/home/eventType/${id1}/event/${id2}`);
        }).catch((error) => {
            alert("Cant delete comment");
            navigate(`/home/eventType/${id1}/event/${id2}`);
        })

    }

    return(
        <div>
            <br></br>
                <h2>All comments</h2>
            <br></br>
            {getUser() != null ?(
                <div className="item-container">
                    <CommentCreateModal id1={id1} id2={id2}></CommentCreateModal>
                </div>
            ): null}
            <br></br>
                <div className="item-container">
                    {comments.map((comment) => (
                        <table id="gameInfo" key={comment.id}>
                            <tr className="tableformat">
                                <th>Comment</th>
                                <th>Date</th>
                                {getUser() != null && getUser().id === Comment.UserId ?(
                                <th>Edit</th>
                                ) : null}
                                {getUser() != null && getUser().id === Comment.UserId ?(
                                <th>Remove</th>
                                ) : null}
                                
                            </tr>
                            <tr className="tableformat">
                                <td>{comment.content}</td>
                                <td>{comment.creationDate}</td>
                                {getUser() != null && getUser().id === Comment.UserId ?(
                                <td><CommentEditModal id1={id1} id2={id2} id3={comment.id}/></td>
                                ) : null}
                                {getUser() != null && getUser().id === Comment.UserId ?(
                                <td><button onClick={ () => RemoveComment(comment.id)}  className="btn btn-danger btn-block">Remove</button></td>
                                ) : null}
                                
                            </tr>
                        </table>
                    ))}
                </div>
        </div>
        
    );
}
export default AllComments;

export class Comments extends Component{
    render(){
        return(
            <div>
                <AllComments></AllComments>
            </div>
        )
    }
}