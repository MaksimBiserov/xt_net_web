class Service
{
    constructor()
    {
        this.userObjects = [];
        this.objectsId = 0;
    }

    add(userObject)
    {
        if (userObject != null && typeof userObject == "object")
        {
            this.objectsId++;
            userObject.id = this.objectsId.toString();
            this.userObjects.push(userObject);
        }
    }

    getById(objectId)
    {
        for (let i = 0; i < this.userObjects.length; i++)
        {
            if (this.userObjects[i].id == objectId && typeof objectId === "string" && objectId != null)
            {
                return this.userObjects[i];
            }
        }
        return null;
    }

    getAll()
    {
        return this.userObjects;
    }

    deleteById(objectId)
    {
        for (let i = 0; i < this.userObjects.length; i++)
        {
            if (objectId != null && this.userObjects[i].id == objectId)
            {
                this.userObjects.splice(i, 1);
                return this.userObjects[i];
            }
        }
        return null;
    }

    updateById(objectId, updateObject)
    {
        if (objectId != null && updateObject != null)
        {
            for (let i = 0; i < this.userObjects.length; i++)
            {
                if (this.userObjects[i].id == objectId)
                {
                    for (let field in updateObject)
                    {
                        this.userObjects[i][field] = updateObject[field];
                    }
                }
            }
        }
    }

    replaceById(objectId, replaceObject)
    {
        if (objectId != null && replaceObject != null)
        {
            for (let i = 0; i < this.userObjects.length; i++)
            {
                if (this.userObjects[i].id == objectId)
                {
                    replaceObject.id = objectId.toString();
                    this.userObjects[i] = replaceObject;
                }
            }
        }
    }
}

module.exports = Service;