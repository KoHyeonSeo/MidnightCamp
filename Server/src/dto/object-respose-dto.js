class ObjectDTO { 
    objectCode;
    objectTextUrl;
    objectTextureUrl;
    objectNormalUrl;
    modelCode;
    modelName;

    constructor(data){
        this.objectCode = data.object_code;
        this.objectTextUrl = data.object_text_url;
        this.objectTextureUrl = data.object_texture_url;
        this.objectNormalUrl = data.object_normal_url;
        this.modelCode = data.model_code;
        this.modelName = data.model_name;
    }
}

module.exports = ObjectDTO;