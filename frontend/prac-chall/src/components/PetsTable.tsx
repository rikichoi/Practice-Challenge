import * as React from 'react';
import { DataGrid, GridColDef, GridFilterModel, GridValueGetterParams } from '@mui/x-data-grid';
import { FormControl, Grid, InputAdornment, InputLabel, OutlinedInput, Paper } from '@mui/material';
import SearchIcon from '@mui/icons-material/Search';
import CloseIcon from '@mui/icons-material/Close';
import { useEffect } from 'react';
import MenuItem from '@mui/material/MenuItem';
import Select from '@mui/material/Select';
// import { Player } from '../models/IPlayer';

// Setting up the columns of the player table
const petColumns: GridColDef[] = [
  { field: 'OwnerID', headerName: 'ID', width: 90, hide: true },
  { field: 'PetName', headerName: 'Pet Name', width: 150, },
  { field: 'Type', headerName: 'Type', width: 150, }
];

const PetsTable: React.FC<any> = (props) => {

  // this takes the props passed to this component and uses it to populate the table
  const petList = props.petList;

  const [filterModel, setFilterModel] = React.useState<GridFilterModel>();

  return (
    // white box around the table
    <Paper
      sx={{
        p: 2,
        display: 'flex',
        flexDirection: 'column',
        height: 'auto',
        maxWidth: 'auto'
      }}
    >
      {/* formats the placement of the searchbar and table */}
      <Grid container spacing={2}>

        <Grid item xl={12} md={12} xs={12}>
          <div style={{ height: '1151px', width: '100%' }}>
            <DataGrid
              rows={petList}
              getRowId={(row) => row.OwnerID}
              columns={petColumns}
              disableColumnMenu={true}
              checkboxSelection={false}
              pageSize={20}
              rowsPerPageOptions={[20]}
              filterModel={filterModel}
              onFilterModelChange={(newFilterModel) => setFilterModel(newFilterModel)}
            />
          </div>
        </Grid>
      </Grid>
    </Paper>
  );
}
export default PetsTable;