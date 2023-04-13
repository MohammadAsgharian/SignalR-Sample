
  
  export const LocalStorage = {
    loadState: (key) => {
      try {
        const serializedState = localStorage.getItem(key);
        if (serializedState === null) {
          return undefined;
        }
        return JSON.parse(serializedState);
      } catch (err) {
        return undefined;
      }
    },
  
    saveState: (key, value) => {
      try {
        localStorage.setItem(key, JSON.stringify(value));
      } catch (err) {}
    },
  
    removeState: (key) => {
      try {
        localStorage.removeItem(key);
      } catch (err) {}
    },
  
    clearState: () => {
      try {
        localStorage.clear();
      } catch (err) {}
    },
  };