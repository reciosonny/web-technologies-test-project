const _topPosition = 100;
var upPosition = 100;
var downPosition = 100;
var leftPosition2 = 140;
var leftPosition = 70;
var init = false;

var greaterElemLeftPosition = 0;
var _constGreaterElemLeftPosition = 0;

var greaterElemUpPosition = 0;
var leastElemLeftPosition = 0;
var _constLeastElemLeftPosition = 0;

var leastElemUpPosition = 0;

var greaterElementTransferComplete = false;
var leastElementTransferComplete = false;

//note: for improvisation
function swapPosition(leastElement, greaterElement) {
    upPosition -= 5;
    downPosition += 5;

    if (!init) {
        //todo: put initialize codes here...
        greaterElementTransferComplete = false;
        leastElementTransferComplete = false;
        
        upPosition = 100;
        downPosition = 100;
        greaterElemLeftPosition = parseInt(greaterElement.style.left.replace('px', ''));
        _constGreaterElemLeftPosition = greaterElemLeftPosition;
        
        greaterElemTopPosition = parseInt(greaterElement.style.top.replace('px', ''));
        
        leastElemLeftPosition = parseInt(leastElement.style.left.replace('px', ''));
        _constLeastElemLeftPosition = leastElemLeftPosition;

        leastElemTopPosition = parseInt(leastElement.style.top.replace('px', ''));
        
        init = true;
        console.log('initializing...');
    }

    if (upPosition > 30) {  
        leastElement.style.top = upPosition+"px";
    } else {
        var styleLeft = parseInt(leastElement.style.left.replace("px",""));

        if (styleLeft > _constGreaterElemLeftPosition) {
            // leftPosition2 -= 5;
            styleLeft-=5;
            leastElement.style.left = styleLeft+"px";
        } else {

            var styleTop = parseInt(leastElement.style.top.replace("px",""));
            if (_topPosition > styleTop) {
                styleTop += 5;
                leastElement.style.top = styleTop+"px";
            } else
                leastElementTransferComplete = true;

        }

    }

    if (downPosition < 170) {
        greaterElement.style.top = downPosition+"px";
    } else {
        var styleLeft = parseInt(greaterElement.style.left.replace("px",""));

        if (styleLeft < _constLeastElemLeftPosition) {
            styleLeft += 5;
            greaterElement.style.left = styleLeft+"px";
        } else {

            var styleTop = parseInt(greaterElement.style.top.replace("px",""));
            if (_topPosition < styleTop) {
                styleTop -= 5;
                greaterElement.style.top = styleTop+"px";
            } else
                greaterElementTransferComplete = true;

        }

    }

    return greaterElementTransferComplete && leastElementTransferComplete;
}