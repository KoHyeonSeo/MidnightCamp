const express = require('express');
const router = express.Router();
const AuthrController = require('../controllers/auth-controller');
const wrapAsyncContoller = require('../middleware/error-handler-middleware');


router.get('/', wrapAsyncContoller(AuthrController.login));
router.post('/regist', wrapAsyncContoller(AuthrController.regist));

module.exports = router;