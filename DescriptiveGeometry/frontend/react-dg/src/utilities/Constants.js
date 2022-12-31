const API_BASE_URL_DEVELOPMENT = 'https://localhost:7039';

const ENDPOINTS = {
    GET_ALL_DRAWINGS: 'api/Drawing',
    GET_DRAWING_BY_ID: 'api/Drawing',
    CREATE_DRAWING: 'api/Drawing',
    UPDATE_DRAWING: 'api/Drawing',
    DELETE_DRAWING: 'api/Drawing'
};

const development = {
    API_URL_GET_ALL_DRAWINGS:`${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.GET_ALL_DRAWINGS}`,
    API_URL_GET_DRAWING_BY_ID:`${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.GET_DRAWING_BY_ID}`,
    API_URL_CREATE_DRAWING:`${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.CREATE_DRAWING}`,
    API_URL_UPDATE_DRAWING:`${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.UPDATE_DRAWING}`,
    API_URL_DELETE_DRAWING:`${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.DELETE_DRAWING}`
};

const production = development;//temp

const Constants = process.env.NODE_ENV === 'development' ? development : production;

export default Constants;
