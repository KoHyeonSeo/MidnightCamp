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

exports.insertModelAndObjects = async (req, res, next) => {
    
    const data = req.body;
    const model = { id : data.user, name : data.name, version : data.version, 
        description : data.description, img_front_url : data.img_front_url,
        img_left_url : data.img_left_url, img_right_url : data.img_right_url
    ,img_rear_url : data.img_rear_url, img_up_url : data.img_up_url}

    const results = await ModelService.insertModel(model);

    const modelId = results.insertId
    const objects = data.blocks;
    objects.map( async (object) => {
        const object_info = {
            modelCode : modelId, objectCode : object.ID, objectRootId : object.rootID,
            objectTextUrl : object.info_url, objectTextureUrl : object.texture_url, objectNormalUrl : object.normal_url
        }
        console.log('object_info: ' , object_info);
        const results_2 = await ModelService.insertObject(object_info);
    })

    


    res.status(HttpStatus.OK).json({
        status: HttpStatus.OK,
        message: 'successfully found all Models',
        results: results
    });
}