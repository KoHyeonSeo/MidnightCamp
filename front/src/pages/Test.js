import axios from "axios";


function Test() {

    const onClickHandler = async () => {
        const test = await axios({
            method: 'post',
            url: '',
            data: {
                
            }
        }) 

    }


    return(
        <div>
            <h1>TEST</h1>
            <button type="button" onClick={ onClickHandler }>테스트</button>
        </div>
    )
}

export default Test;