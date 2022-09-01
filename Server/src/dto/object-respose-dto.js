class ObjectDTO { 
    objectCode;
    objectRootId;
    objectID;
    objectTextUrl;
    objectTextureUrl;
    objectNormalUrl;
    modelCode;
    modelName;

    constructor(data){
        this.objectCode = data.object_code;
        this.objectRootId = data.object_root_id;
        this.objectID = data.object_id;
        this.objectTextUrl = data.object_text_url;
        this.objectTextureUrl = data.object_texture_url;
        this.objectNormalUrl = data.object_normal_url;
        this.modelCode = data.model_code;
        this.modelName = data.model_name;
    }
}

module.exports = ObjectDTO;