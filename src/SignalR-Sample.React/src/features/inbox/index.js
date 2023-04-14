import { useEffect } from 'react';
import { styled} from '@mui/material/styles';
import CssBaseline from '@mui/material/CssBaseline';
import Box from '@mui/material/Box';
import MuiAppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import { HubConnectionBuilder } from '@microsoft/signalr';
import { LocalStorage } from '../../utils/local-storage';

const AppBar = styled(MuiAppBar, {
  shouldForwardProp: (prop) => prop !== 'open',
})(({ theme }) => ({
  zIndex: theme.zIndex.drawer + 1,
  transition: theme.transitions.create(['width', 'margin'], {
    easing: theme.transitions.easing.sharp,
    duration: theme.transitions.duration.leavingScreen,
  }),
}));



function InboxdContent() {
  useEffect(()=>{
  
    const connection = 
    new HubConnectionBuilder()  
      .withUrl("https://localhost:44379/messageHub",
      {
        accessTokenFactory :()=>LocalStorage.loadState("Token")
      })  
    .withAutomaticReconnect()
    .build();  
    connection.start().then(() => { // to start the server
      console.log('server connected!!!');
    }).catch(err => console.log(err));
  }
  ,[]);
  
  return (
    <Box sx={{ display: 'flex' }}>
        <CssBaseline />
        <AppBar position="absolute" >
          <Toolbar
            sx={{
              pr: '24px', // keep right padding when drawer closed
            }}
          >
            <Typography
              component="h1"
              variant="h6"
              color="inherit"
              noWrap
              sx={{ flexGrow: 1 }}
            >
              Inbox
            </Typography>
          </Toolbar>
        </AppBar>
        
      </Box>
  );
}

export default function Inbox() {
  return <InboxdContent />;
}