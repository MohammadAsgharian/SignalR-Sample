import { useEffect } from "react";
import CssBaseline from "@mui/material/CssBaseline";
import Box from "@mui/material/Box";
import { CustomAppBar } from "../../../components/AppBar";
import { useSignalRConnection } from "../../../hooks/useSignalRConnection";

const InboxMessage = () => {
  const { connection, startConnection } = useSignalRConnection(
    "https://localhost:44379/messageHub"
  );

  useEffect(() => {
    const connect = async () => {
      try {
        await startConnection();
        console.log("Server connected!!!");
      } catch (error) {
        console.log(error);
      }
    };

    connect();
  }, [startConnection]);

  useEffect(() => {
    if (connection !== null) {
      connection.on("MessageToUser", (message) => {
        console.log(message);
      });
    }
  }, [connection]);

  return (
    <Box sx={{ display: "flex" }}>
      <CssBaseline />
      <CustomAppBar title="Inbox" />
    </Box>
  );
};

export default InboxMessage;
