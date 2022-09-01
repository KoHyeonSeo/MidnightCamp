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
    const data = req.query;
    console.log(data);
    const results = await ModelService.searchModels(data);

    res.status(HttpStatus.OK).json({
        status: HttpStatus.OK,
        message: 'successfully found all Models',
        results: results
    });
}


exports.searchDetailByCode = async (req, res, next) => {
    const code = req.params;
    const results = await ModelService.searchDetailByCode(code);

    res.status(HttpStatus.OK).json({
        status: HttpStatus.OK,
        message: 'successfully found all Models',
        results: results
    });
}

exports.insertModel = async (req, res, next) => {
    

    res.status(HttpStatus.OK).json({
        status: HttpStatus.OK,
        message: 'successfully found all Models',
        results: results
    });
}