class ModelDTO { 
    modelCode;
    modelName;
    modelVersion;
    groupId;
    groupName;
    imgFrontUrl;
    imgLeftUrl;
    imgRightUrl;
    imgBackUrl;
    imgUpUrl;

    constructor(data){
        this.modelCode = data.model_code;
        this.modelName = data.model_name;
        this.modelVersion = data.model_version;
        this.groupId = data.group_id;
        this.groupName = data.group_name;
        this.imgFrontUrl = data.img_front_url;
        this.imgLeftUrl = data.img_left_url;
        this.imgRightUrl = data.img_right_url;
        this.imgBackUrl = data.img_rear_url;
        this.imgUpUrl = data.img_up_url;
    }
}

module.exports = ModelDTO;