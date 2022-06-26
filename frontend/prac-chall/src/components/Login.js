import React, {useContext} from 'react'
import { Button, Card, CardContent, TextField, Typography } from '@mui/material'
import { Box } from '@mui/system'
import Center from './Center';
import useForm from '../hooks/useForm'
import { useNavigate } from 'react-router'
import axios from 'axios';
import {LoginContext} from '../helper/Context';

const getFreshModel = () => ({
    username: '',
    password: ''
})

export default function Login() {

    const navigate = useNavigate();

    const {userID, setUserID} = useContext(LoginContext);

    const {
        values,
        errors,
        setErrors,
        handleInputChange
    } = useForm(getFreshModel);

    
    const [navigation,setNavigation] = React.useState('');



    const login = e => {
        e.preventDefault();
        if (validate())
        {
                axios.get(`https://localhost:7162/api/TblOwners/Login/${values.username}/${values.password}`)
                .then(res => {
                    if(res.data.userValid === true)
                    {
                        setUserID(res.data.ownerid);
                        console.log(userID);
                        setNavigation('/home');
                    }
                    else
                    {
                        setNavigation('');
                        console.log(userID);
                    }
                })
                .catch(err => {
                    setNavigation('');
                    console.log(err)
                })
        }
    }


    const validate = () => {
        let temp = {}
        temp.username = values.username !=="" ? "" : "This field is required."
        temp.password = values.password !== "" ? "" : "This field is required."
        setErrors(temp)
        return Object.values(temp).every(x => x === "")
    }

    return (
        <Center>
            <Card sx={{ width: 400 }}>
                <CardContent sx={{ textAlign: 'center' }}>
                    <Typography variant="h3" sx={{ my: 3 }}>
                        Login
                    </Typography>
                    <Box sx={{
                        '& .MuiTextField-root': {
                            m: 1,
                            width: '90%'
                        }
                    }}>
                        <form noValidate autoComplete="off" onSubmit={login}>
                            <TextField
                                label="Username"
                                name="username"
                                value={values.username}
                                onChange={handleInputChange}
                                variant="outlined"
                                {...(errors.username && { error: true, helperText: errors.username })} />
                            <TextField
                                label="Password"
                                name="password"
                                type='password'
                                value={values.password}
                                onChange={handleInputChange}
                                variant="outlined"
                                {...(errors.password && { error: true, helperText: errors.password })} />
                            <Button
                                type="submit"
                                variant="contained"
                                size="large"
                                sx={{ width: '90%', m:1 }}
                                onClick={() => navigate(`${navigation}`)}>Login</Button>
                        </form>
                        <Button
                                variant="contained"
                                size="large"
                                sx={{ width: '90%', m:1 }}
                                onClick={() => navigate('/')}>Return</Button>

                    </Box>
                </CardContent>
            </Card>
        </Center>
    )
}