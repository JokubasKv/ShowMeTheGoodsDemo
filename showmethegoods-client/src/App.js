import './App.css';
import {Home} from './Routes/Home';
import {BrowserRouter, Route , Routes , NavLink} from 'react-router-dom';


import { EventTypeComponent } from './Components/EventType/CreateEventType';
import Register from './Routes/Register';
import Login from './Routes/Login';
import { EditEventTypeComponent } from './Components/EventType/EditEventType';
import { Events } from './Routes/Events';
import { Event } from './Routes/Event';
import { Comments } from './Routes/Comments';
import { Container, Fade, Navbar } from 'react-bootstrap';
import titleImage from './titleBackground.png';
import AuthUser from './Services/AuthUser';


function App() {

  const { http, getUser, getToken } = AuthUser();


const logout = () => {
  sessionStorage.clear();
  window.location.href = "http://localhost:3000/home";
}

  return (
    

    <div className="AppContainer">
    <div style={{ backgroundImage: `url(${titleImage})` }}>
      <b>
        <h1 className='display-1 d-flex justify-content-center m-5'>
          Show Me The Goods Website
        </h1>
      </b>
    </div>
    <Navbar bg="light" expand="lg">
    <Container>
    <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <NavLink className='btn btn-light btn-outline-dark' to ='/home'>
            Home
          </NavLink>
          <NavLink className='btn btn-light btn-outline-dark' to ='/register'>
            Register
          </NavLink>
          <NavLink className='btn btn-light btn-outline-dark' to ='/login'>
            Login
          </NavLink>
          <NavLink onClick={logout} className='btn btn-light btn-outline-dark'>
            Log out
          </NavLink>
          <Navbar.Collapse className="justify-content-end">
          <Navbar.Text>
             {getUser()? <>Signed in as:<a href="/login">{getUser()}</a></> : <a href="/login">Not signed in</a>}
          </Navbar.Text>
        </Navbar.Collapse>
        </Container>
      </Navbar>

      <Routes>
        <Route path = '/home' element={<Home/>}/>
        <Route path = '/' element={<Home/>}/>
        <Route path = 'home/api/eventType' element={<EventTypeComponent/>}/>
        <Route path = 'home/api/eventType/:id1' element={<EditEventTypeComponent/>}/>
        <Route path = 'home/api/eventType/:id1/event' element={<Events/>}/>
        <Route path = 'home/api/eventType/:id1/event/:id2' element={<Event/>}/>
        <Route path = 'home/api/eventType/:id1/event/:id2/comments' element={<Comments/>}/>
        <Route path = '/register' element={<Register/>}/>
        <Route path = '/login' element={<Login/>}/>
      </Routes>
    </div>
  );
}

export default App;
