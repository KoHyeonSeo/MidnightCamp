const ftp = require("basic-ftp");

async function download(){
   const client = new ftp.Client();
     client.ftp.verbose = false; // 자세한 통신과정을 보고 싶으면 true, 생략하고 싶으면 false로 설정하면 된다.
     try{
      await client.access({
        host: "metaverse.ohgiraffers.com",
        user: "test04",
        password: "pass04"
      });
      await client.cd("/test04"); // 서버에 접속 후 서버에 만들어둔 Test 폴더로 이동
      await client.downloadTo("file/test24.jpg", "test22.jpg"); 
      // 첫번째 인자는 다운로드 파일 서버 저장 경로, 두번째 인자는 다운로드 받을 파일 ftp 경로
    } catch (err){
      console.log(err);
      client.close();
      return false;
    }
  
     client.close();
     return true;
}

download();