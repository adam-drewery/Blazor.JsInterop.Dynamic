// noinspection JSUnresolvedFunction,JSUnresolvedVariable

// method wrapper for preparing arguments
window.xa6dd4ca4880643aa86eb9d18af009fc3 = async function(instance, methodName, ...args) {
    
    const processedArgs = args.map(arg => {

        console.log("processing: " + JSON.stringify(arg))
        
        // handle convert blob to byte array
        if (arg.identifier === 'x568c8d7489ac46a1926565b18249fa9e') {
            console.log("transforming blob")
            return new Blob([arg.bytes]);
        }

        // handle callback wrapper
        if (arg.identifier === 'x35386dab52f3434d8bc774ef426222b5') {

            if (arg.params.isVoid) {
                console.log("transforming void callback")
                return (...x) => {
                    
                    console.log("callback invoked with: " + JSON.stringify(x))
                    arg.reference.invokeMethodAsync('Callback', ...x);
                }
            } else {
                console.log("transforming function callback")
                return (...x) => {
                    console.log("callback invoked with: " + JSON.stringify(x))
                    return arg.reference.invokeMethodAsync('Callback', ...x);
                }
            }
        }
        return arg;
    });

    if (instance && typeof instance[methodName] === 'function') {

        console.log("executing internal function: " + instance + "." + methodName + "(" + processedArgs + ")");
        let result = instance[methodName](...processedArgs);
        
        // Check if result is a promise
        if (result instanceof Promise) {
            console.log("awaiting promise: " + typeof result)
            result = await result;
        }

        if (typeof result === 'function') {
            console.log("returning function result: " + result)
            result = result();
        }
        
        if (typeof result === 'object') {
            console.log("checking object: " + result)
            
            // set the function that can be used to retrieve properties
            result.x04f665b3ad2c47a3a02b181a447bd82f = function () { 
                let sanitized = {};
                for (let key in result) {
                    let value = result[key];

                    // todo: replace with some sort of reference that can be serialized
                    if (typeof value === 'object') { sanitized[key] = null; }
                    else { sanitized[key] = value; }
                }
                return sanitized; 
            }
            return result;
        } else {
            console.log("wrapping primitive: " + result)
            return { x04f665b3ad2c47a3a02b181a447bd82f: function() { return result } };
        }
    } else {
        console.error(`Method ${methodName} is not defined on the provided instance.`);
    }
}