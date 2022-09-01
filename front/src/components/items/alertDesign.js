import Swal from "sweetalert2";

export function signupSuccessAlert(){
  Swal.fire({
    title: '회원 가입 성공',
    text: `회원 가입을 성공했습니다. 메인 화면으로 이동합니다.`,
    icon: 'success',
    confirmButtonColor: '#3085d6',
    cancelButtonColor: '#d33',
    confirmButtonText: '확인',
  }).then((result) => {
    if (result.value) {
        //"
    }
  })
}

export function loginSuccessAlert(id){
    Swal.fire({
      title: '로그인 성공',
      text: `${id}님 환영합니다.`,
      icon: 'success',
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: '확인',
    }).then((result) => {
      if (result.value) {
          //
      }
    })
}

export function loginFailAlert(){
    Swal.fire({
      title: '로그인 실패',
      text: '아이디 혹은 비밀번호를 잘못 입력했습니다.',
      icon: 'error',
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: '확인',
    }).then((result) => {
      if (result.value) {
          //
      }
    })
}

export function logoutAlert(){
    Swal.fire({
      title: '로그아웃',
      text: '로그아웃 하였습니다. 안녕히가세요!',
      icon: 'success',
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: '확인',
    })
}

export function writeBoardAlert(){
    Swal.fire({
      title: '로그인 요청',
      text: '로그인이 필요한 서비스입니다.',
      icon: 'info',
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: '확인',
    })
}

export function writeBoardSuccessAlert(){
  Swal.fire({
    title: '게시물 등록 성공',
    text: '게시물을 등록하였습니다.',
    icon: 'success',
    confirmButtonColor: '#3085d6',
    cancelButtonColor: '#d33',
    confirmButtonText: '확인',
  })
}

export function writeBoardFailAlert(){
  Swal.fire({
    title: '게시물 등록 실패',
    text: '제목과 내용을 모두 입력해주세요.',
    icon: 'error',
    confirmButtonColor: '#3085d6',
    cancelButtonColor: '#d33',
    confirmButtonText: '확인'
  })
}

export function writeBoardCancleAlert(navBack){
  Swal.fire({
    title: '게시물 등록 취소',
    text: '게시물 등록을 취소하시겠습니까?',
    icon: 'question',
    showCancelButton: true,
    confirmButtonColor: '#183981',
    cancelButtonColor: '#183981',
    confirmButtonText: '확인',
    cancelButtonText: '취소'
  }).then(res => {
    if(res.isConfirmed) {
      navBack();
    }
  })
}

// export function deleteBoard(seq){
//     Swal.fire({
//       title: '글을 삭제하시겠습니까???',
//       text: "삭제하시면 다시 복구시킬 수 없습니다.",
//       icon: 'warning',
//       showCancelButton: true,
//       confirmButtonColor: '#3085d6',
//       cancelButtonColor: '#d33',
//       confirmButtonText: '삭제',
//       cancelButtonText: '취소'
//     }).then((result) => {
//       if (result.value) {
//           //"삭제" 버튼을 눌렀을 때 작업할 내용을 이곳에 넣어주면 된다. 
//       }
//     })
// }