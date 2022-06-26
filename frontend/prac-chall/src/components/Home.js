import * as React from 'react';
import AppBar from '@mui/material/AppBar';
import { Button, Card, CardContent, Typography, TextField } from '@mui/material'
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import IconButton from '@mui/material/IconButton';
import Menu from '@mui/material/Menu';
import Container from '@mui/material/Container';
import Tooltip from '@mui/material/Tooltip';
import MenuItem from '@mui/material/MenuItem';
import { useNavigate } from 'react-router-dom';
import AccountCircleIcon from '@mui/icons-material/AccountCircle';
import Center from './Center';
import { LoginContext } from '../helper/Context';
import { useState, useEffect, useContext } from 'react';
import axios from 'axios';


const Home = () => {

  const { userID, setUserID } = useContext(LoginContext);

  const navigate = useNavigate();

  const [anchorElUser, setAnchorElUser] = React.useState(null);

  const handleOpenUserMenu = (event) => {
    setAnchorElUser(event.currentTarget);
  };

  const handleCloseUserMenu = () => {
    setAnchorElUser(null);
  };

  const handleLogout = () => {
    setUserID(0);
    navigate(`/`)
  };


  const [pets, setPets] = useState([]);

  const [procedures, setProcedures] = useState([]);

  const [updated, setUpdated] = useState(false);


  useEffect(() => {
    axios.get(`https://localhost:7162/api/TblPets/Pets/${userID}`)
      .then(resp => {
        setPets(resp.data.ownerPetsObject);
      }
      )
  }, [userID, updated]);

  useEffect(() => {
    axios.get(`https://localhost:7162/api/TblProcedures`)
      .then(resp => {
        setProcedures(resp.data);
      }
      )
  }, [userID]);

  const [toggle, setToggle] = useState(false);

  const [petname, setPetname] = useState("");

  const [type, setType] = useState("");


  

  return (
    <>
      <AppBar position="static">
        <Container maxWidth="xl">
          <Toolbar disableGutters>
            <Typography
              variant="h6"
              noWrap
              component="a"
              sx={{
                mr: 2,
                display: { xs: 'flex', md: 'flex' },
                fontFamily: 'monospace',
                fontWeight: 700,
                letterSpacing: '.3rem',
                color: 'inherit',
                textDecoration: 'none',
              }}
            >
              PRACTICE CHALLENGE
            </Typography>

            <Box sx={{ flexGrow: 0, marginLeft: 'auto' }}>
              <Tooltip title="Open settings">
                <IconButton onClick={handleOpenUserMenu} sx={{ p: 0 }}>
                  <AccountCircleIcon style={{ fontSize: 50 }} />
                </IconButton>
              </Tooltip>
              <Menu
                sx={{ mt: '60px' }}
                id="menu-appbar"
                anchorEl={anchorElUser}
                anchorOrigin={{
                  vertical: 'top',
                  horizontal: 'right',
                }}
                keepMounted
                transformOrigin={{
                  vertical: 'top',
                  horizontal: 'right',
                }}
                open={Boolean(anchorElUser)}
                onClose={handleCloseUserMenu}
              >
                <MenuItem onClick={handleLogout}>
                  <Typography textAlign="center">Logout</Typography>
                </MenuItem>
              </Menu>
            </Box>
          </Toolbar>
        </Container>
      </AppBar>


      <Center>
        <Card sx={{ width: 500, m: 2 }}>
          <CardContent sx={{ textAlign: 'center' }}>
            <Typography variant="h5" sx={{ my: 3 }}>
              Pets
            </Typography>
            <Button onClick={() => setToggle(!toggle)} variant="contained" sx={{ my: 3 }}>Add Pet</Button>
            {toggle && (
              <div>
              <TextField
              sx={{ marginRight: 1 }}
                label="Pet Name"
                name="petname"
                type='petname'
                value={petname}
                onChange={(e) => {
                  setPetname(e.target.value); }}
                variant="outlined"/>
                <TextField
                sx={{ marginLeft: 1 }}
                label="Type"
                name="type"
                type='type'
                value={type}
                onChange={(e) => {
                  setType(e.target.value); }}
                variant="outlined"/>
                <Button onClick={() => ( setUpdated(!updated),
                axios.post(`https://localhost:7162/api/TblPets`, {
                  ownerid : userID,
                  petname : petname,
                  type : type
                }).then(resp => console.log(resp).catch(err => console.log(err))))} 
                variant="contained" sx={{ marginRight: 3, my:3 }} color="success">Submit</Button>
                <Button onClick={() => (setToggle(!toggle), setPetname(""), setType(""))} 
                variant="contained" sx={{ marginLeft: 3, my:3 }} color="error">Close</Button>
                </div>
            )}
          </CardContent>
          <CardContent sx={{ textAlign: 'left' }}>
            {pets.map(pets => {
              return (
                <div className='post'>
                  <h3>{pets.petname}</h3>
                  <p>{pets.type}</p>
                  <Button variant="contained" sx={{ my: 3 }} color="error"
                  onClick={() => (setUpdated(!updated),
                    axios.delete(`https://localhost:7162/api/TblPets/${pets.petname}/${pets.ownerid}`).then(resp => console.log(resp).catch(err => console.log(err))))} 
                    >Remove</Button>
                </div>
              )
            })}
          </CardContent>
        </Card>


        <Card sx={{ m: 2 }}>
          <CardContent sx={{ textAlign: 'center' }}>
            <Typography variant="h5" sx={{ my: 3 }}>
              Treatments
            </Typography>
          </CardContent>
        </Card>

        <Card sx={{ m: 2 }}>
          <CardContent sx={{ textAlign: 'center' }}>
            <Typography variant="h5" sx={{ my: 3 }}>
              Offered Procedures
            </Typography>
          </CardContent>
          <CardContent sx={{ textAlign: 'left' }}>
            {procedures.map(procedures => {
              return (
                <div className='post'>
                  <h3>Procedure ID: {procedures.procedureid}</h3>
                  <p>Description: {procedures.description}</p>
                  <p>Price: {procedures.price}$</p>
                </div>
              )
            })}
          </CardContent>
        </Card>
      </Center>
    </>
  );
};
export default Home;
