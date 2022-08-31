exports.selectAllModels = () =>{
    return `
        SELECT
               A.model_code
             , A.model_name
             , A.group_id
             , B.group_name
             , A.model_info_url
             , A.img_front_url
             , A.img_left_url
             , A.img_right_url
             , A.img_back_url
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
             , A.model_info_url
             , A.img_front_url
             , A.img_left_url
             , A.img_right_url
             , A.img_back_url
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
             , A.model_info_url
             , A.img_front_url
             , A.img_left_url
             , A.img_right_url
             , A.img_back_url
             , A.img_up_url
          FROM TBL_MODEL A
          JOIN TBL_GROUP B on A.group_id = B.group_id
         WHERE A.model_name Like ?;
    `
}