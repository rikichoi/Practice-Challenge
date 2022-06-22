import React from 'react';
import { Button, Card, CardContent, Typography } from '@mui/material'
import { Box } from '@mui/system'
import Center from './Center';
import { useNavigate } from 'react-router';
export default function Entry() {

    let navigate = useNavigate();

    return(
      <Center>
          <Card sx={{ width: 400 }}>
              <CardContent sx={{ textAlign: 'center' }}>
                  <Typography variant="h3" sx={{ my: 3 }}>
                      Practice Challenge
                  </Typography>
                  <Box sx={{
                      '& .MuiTextField-root': {
                          m: 1,
                          width: '90%'
                      }
                  }}>
                        <Button
                              type="submit"
                              variant="contained"
                              size="large"
                              sx={{ width: '90%', m: 2 }}
                              onClick={() => navigate('login')}>Log In</Button>
                        <Button
                              type="submit"
                              variant="contained"
                              size="large"
                              sx={{ width: '90%'}}
                              onClick={() => navigate('signup')}>Sign Up</Button>  
                  </Box>
              </CardContent>
          </Card>
      </Center>
  )
}
