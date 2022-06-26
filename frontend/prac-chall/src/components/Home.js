import * as React from 'react';
import AppBar from '@mui/material/AppBar';
import { Button, Card, CardContent, Typography } from '@mui/material'
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import IconButton from '@mui/material/IconButton';
import Menu from '@mui/material/Menu';
import Container from '@mui/material/Container';
import Tooltip from '@mui/material/Tooltip';
import MenuItem from '@mui/material/MenuItem';
import { useNavigate } from 'react-router-dom';
import AccountCircleIcon from '@mui/icons-material/AccountCircle';
import Center from './Center'
import { LoginContext } from '../helper/Context';
import { useContext } from 'react';

const Home = () => {

  const {userID, setUserID} = useContext(LoginContext);

  const navigate = useNavigate();

  const [anchorElUser, setAnchorElUser] = React.useState(null);

  const handleOpenUserMenu = (event) => {
    setAnchorElUser(event.currentTarget);
  };

  const handleCloseUserMenu = () => {
    setAnchorElUser(null);
  };





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


            <Box sx={{ flexGrow: 0, display: { xs: 'flex', md: 'flex' } }}>
              <Button
                onClick={() => navigate(`/pets`)}
                sx={{ m: 2, color: 'white', display: 'block' }}
              >
                PETS
              </Button>
            </Box>

            <Box sx={{ flexGrow: 0, display: { xs: 'flex', md: 'flex' } }}>
              <Button
                onClick={() => navigate(`/treatments`)}
                sx={{ m: 2, color: 'white', display: 'block' }}
              >
                TREATMENTS
              </Button>
            </Box>

            <Box sx={{ flexGrow: 0, display: { xs: 'flex', md: 'flex' } }}>
              <Button
                onClick={() => navigate(`/procedures`)}
                sx={{ m: 2, color: 'white', display: 'block' }}
              >
                PROCEDURES
              </Button>
            </Box>

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
                <MenuItem onClick={handleCloseUserMenu}>
                  <Typography textAlign="center">Logout</Typography>
                </MenuItem>
              </Menu>
            </Box>
          </Toolbar>
        </Container>
      </AppBar>


      <Center>
        <Card sx={{ width: 400, m:2 }}>
          <CardContent sx={{ textAlign: 'center' }}>
            <Typography variant="h5" sx={{ my: 3 }}>
              Pets
            </Typography>
          </CardContent>
          <CardContent sx={{ textAlign: 'center' }}>
                
          </CardContent>
        </Card>

        <Card sx={{ width: 400, m:2 }}>
          <CardContent sx={{ textAlign: 'center' }}>
            <Typography variant="h5" sx={{ my: 3 }}>
              Treatments
            </Typography>
          </CardContent>
        </Card>

        <Card sx={{ width: 400, m:2 }}>
          <CardContent sx={{ textAlign: 'center' }}>
            <Typography variant="h5" sx={{ my: 3 }}>
              Offered Procedures
            </Typography>
          </CardContent>
        </Card>
      </Center>
    </>
  );
};
export default Home;
