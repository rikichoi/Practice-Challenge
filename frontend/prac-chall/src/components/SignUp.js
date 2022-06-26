import React from 'react'
import { Button, Card, CardContent, TextField, Typography } from '@mui/material'
import { Box } from '@mui/system'
import Center from './Center'
import useForm from '../hooks/useForm'
import { createAPIEndpoint, ENDPOINTS } from '../api'
import { useNavigate } from 'react-router'

const getFreshModel = () => ({
    ownerid: 0,
    surname: '',
    firstname: '',
    phone: '',
    username: '',
    password: '',
    admin: false
})

export default function SignUp() {

    const navigate = useNavigate()

    const [navigation,setNavigation] = React.useState('');

    const {
        values,
        errors,
        setErrors,
        handleInputChange
    } = useForm(getFreshModel);

    const login = e => {
        e.preventDefault();
        if (validate())
        {
            createAPIEndpoint(ENDPOINTS.TblOwners)
                .post(values)
                .then(res => {
                    if(res.status === 200)
                    {
                        setNavigation('/login');
                    }
                    else
                    {
                        setNavigation('');
                    }
                })
                .catch(err => console.log(err))                
        }
    }

    const validate = () => {
        let temp = {}
        temp.surname = values.surname !== "" ? "" : "This field is required."
        temp.firstname = values.firstname !== "" ? "" : "This field is required."
        temp.phone = values.phone !== "" ? "" : "This field is required."
        temp.username = values.username !== "" ? "" : "This field is required."
        temp.password = values.password !== "" ? "" : "This field is required."
        setErrors(temp)
        return Object.values(temp).every(x => x === "")
    }

    return (
        <Center>
            <Card sx={{ width: 400 }}>
                <CardContent sx={{ textAlign: 'center' }}>
                    <Typography variant="h3" sx={{ my: 3 }}>
                        Sign Up
                    </Typography>
                    <Box sx={{
                        '& .MuiTextField-root': {
                            m: 1,
                            width: '90%'
                        }
                    }}>
                        <form noValidate autoComplete="off" onSubmit={login}>
                        <TextField
                                label="First Name"
                                name="firstname"
                                value={values.firstname}
                                onChange={handleInputChange}
                                variant="outlined"
                                {...(errors.firstname && { error: true, helperText: errors.firstname })} />
                            <TextField
                                label="Last Name"
                                name="surname"
                                value={values.surname}
                                onChange={handleInputChange}
                                variant="outlined"
                                {...(errors.surname && { error: true, helperText: errors.surname })} />
                            <TextField
                                label="Phone Number"
                                name="phone"
                                value={values.phone}
                                onChange={handleInputChange}
                                variant="outlined"
                                {...(errors.phone && { error: true, helperText: errors.phone })} />
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
                                sx={{ width: '90%', m:1  }}
                                onClick={() => navigate(`${navigation}`)}>Sign Up</Button>
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