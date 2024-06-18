import { Container } from 'semantic-ui-react'
import './App.css'
import CategoryTable from './components/CategoryTable'
import { Outlet, useLocation } from 'react-router-dom'
import { useEffect } from 'react';
import { setupErrorHandlingInterceptor } from './interceptors/axiosInterceptors';

function App() {
  const location = useLocation();

  useEffect(() => {
    setupErrorHandlingInterceptor();
  }, []);

  return (
    <>
      {location.pathname === '/' ? <CategoryTable /> : (
        <Container className='container-style'>
          <Outlet />
        </Container>
      )}
    </>
  )
}

export default App
