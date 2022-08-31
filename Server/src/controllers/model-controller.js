const ModelService = require('../services/model-service')
const HttpStatus = require('http-status');


exports.searchAllModels = async (req, res, next) => {
    const results = await ModelService.searchAllModels();

    res.status(HttpStatus.OK).json({
        status: HttpStatus.OK,
        message: 'successfully found all Models',
        results: results
    });
}

exports.searchModels = async (req, res, next) => {
    const data = req.query
    const results = await ModelService.searchModels(data);

    res.status(HttpStatus.OK).json({
        status: HttpStatus.OK,
        message: 'successfully found all Models',
        results: results
    });
}