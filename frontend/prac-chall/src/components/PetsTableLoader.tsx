import { useEffect, useState } from 'react';
import PetsTable from './PetsTable';
import axios from 'axios'
import { Pet } from '../models/IPet';
import * as React from 'react';

interface PetProps{
    petList: Pet[];
}

function PlayerTableLoader() {
  
  const [appState, setAppState] = useState<PetProps>({
    petList: [],
  });
  // defines a state for whenever an error occurs
  const [errorMessage, setErrorMessage] = useState("");
    // defines a state for when the api is fetching data for players
  const [isLoading, setLoading] = useState(false);

  const getUserPets = async () => {
    setAppState({ petList: [] });

    axios.get(`https://localhost:7162/api/TblPets`)
    .then(pets => {
        setAppState({ petList: pets as unknown as Pet[] });
        setLoading(false);
    })
        .catch(err => {
            console.log(err)
        })
    };

  // this is the call to the API to get the player data
  useEffect(() => {
    getUserPets()
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [setAppState]);

  return (
    <>
  {/* if the error message is not empty or does not equal "", then the error message will appear*/}
        {errorMessage!==""&&<h1 style={{color: 'red'}}>Oops! An Error Occured Please Try Again.</h1>}
  {/* if  isLoading is true, loading text will apear, if api is able to fetch player data and isLoading is false, then show filled player table*/}
        {isLoading ? (<h1>Hold on, fetching data may take some time :)</h1>) : (<PetsTable petList={appState.petList} />)}
    </>

  );
}
export default PlayerTableLoader;