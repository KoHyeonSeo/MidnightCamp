exports.selectUserByIdAndPassword = () => {

    return `
        SELECT
               A.group_id
             , A.group_name
          FROM tbl_group A
         WHERE A.group_id = ? and A.group_pwd = ?;
    `
}

exports.insertAuth = () => {
    return `
            INSERT
              INTO tbl_group(group_id, group_pwd, group_name)
            VALUES (?, ?, ?)
        `
}
