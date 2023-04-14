/*eslint no-unused-expressions: "error"*/
import { useState, useEffect, useCallback } from 'react';
import { HubConnectionBuilder } from '@microsoft/signalr';
import { LocalStorage } from '../utils/local-storage';

export const useSignalRConnection = (url) => {
  const [connection, setConnection] = useState(null);

  const startConnection = useCallback(async () => {
    const newConnection = new HubConnectionBuilder()
      .withUrl(url, {
        accessTokenFactory: () => LocalStorage.loadState('Token')
      })
      .withAutomaticReconnect()
      .build();

    await newConnection.start();
    setConnection(newConnection);
  }, [url]);

  useEffect(() => {
    return () => {
      if (connection) {
        connection.stop();
        setConnection(null);
      }
    };
  }, [connection]);

  return {
    connection,
    startConnection
  };
};
