exports.selectAllModels = () =>{
    return `
        SELECT
               A.model_code
             , A.model_name
             , A.group_id
             , B.group_name
             , A.img_front_url
             , A.img_left_url
             , A.img_right_url
             , A.img_rear_url
             , A.img_up_url
          FROM TBL_MODEL A
          JOIN TBL_GROUP B on A.group_id = B.group_id
    `
}

exports.selectModelsByGroupId = () => {
    return `
        SELECT
               A.model_code
             , A.model_name
             , A.group_id
             , B.group_name
             , A.img_front_url
             , A.img_left_url
             , A.img_right_url
             , A.img_rear_url
             , A.img_up_url
          FROM TBL_MODEL A
          JOIN TBL_GROUP B on A.group_id = B.group_id
         WHERE A.group_id = ?
    `
}

exports.selectModelsByModelName = () => {
    return `
        SELECT
               A.model_code
             , A.model_name
             , A.group_id
             , B.group_name
             , A.img_front_url
             , A.img_left_url
             , A.img_right_url
             , A.img_rear_url
             , A.img_up_url
          FROM TBL_MODEL A
          JOIN TBL_GROUP B on A.group_id = B.group_id
         WHERE A.model_name Like ?
    `
}

exports.selectModelDetailByCode = () => {
    return `
        SELECT
               A.object_code
             , A.model_code
             , B.model_name
             , A.object_text_url
             , A.object_texture_url
             , A.object_normal_url
          FROM TBL_OBJECT A
          JOIN TBL_MODEL B on A.model_code = B.model_code
         WHERE A.model_code = ?
    `
}