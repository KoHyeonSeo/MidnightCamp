const express = require('express');
const router = express.Router();
const ModelController = require('../controllers/model-controller');
const wrapAsyncContoller = require('../middleware/error-handler-middleware');

router.get('/', wrapAsyncContoller(ModelController.searchAllModels));
router.get('/search', wrapAsyncContoller(ModelController.searchModels));
router.get('/search/:code', wrapAsyncContoller(ModelController.searchDetailByCode));

router.post('/', wrapAsyncContoller(ModelController.insertModel));
router.post('/object', wrapAsyncContoller(ModelController.insertObject));


module.exports = router;