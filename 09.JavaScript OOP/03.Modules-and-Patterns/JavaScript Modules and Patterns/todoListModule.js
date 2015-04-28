var ListModule = (function () {
    'use strict';

    Object.prototype.extends = function (parent) {
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    }

    var ListElement = (function () {
        function ListElement(title) {
            this._setTitle(title);
        }

        ListElement.prototype._setTitle = function (title) {
            if (!title) {
                throw TypeError('Invalid title: ' + title);
            }

            this._title = title;
        }

        ListElement.prototype.getTitle = function() {
            return this._title;
        }

        ListElement.prototype.getHtmlElement = function () {
            if (!this._htmlElement) {
                this._buildHtmlElement();
            }

            return this._htmlElement;
        }

        ListElement.prototype._buildHtmlElement = function () {
            this._htmlElement = null;
        }

        ListElement.prototype.addToDom = function (parent) {
            if (!this._htmlElement) {
                this._buildHtmlElement();
            }

            parent.appendChild(this._htmlElement);
        }

        return ListElement;
    })();

    var Container = (function () {
        var counter = 0;
        function Container(containerTitle) {
            ListElement.call(this, containerTitle);
            counter += 1;
        }

        Container.extends(ListElement);
        Container.prototype._buildHtmlElement = function () {
            var containerHeader = document.createElement('h1');
            containerHeader.innerHTML = this.getTitle();

            var sectionsContainer = document.createElement('div');
            sectionsContainer.className = 'sections';

            var inputField = document.createElement('input');
            inputField.type = 'text';
            inputField.placeholder = 'Title...';

            var newSectionButton = document.createElement('button');
            newSectionButton.className = 'addSectionBtn';
            newSectionButton.innerHTML = 'New Section';
            newSectionButton.addEventListener('click', function () {
                addNewSection(sectionsContainer, inputField.value);
                inputField.value = '';
            }, false);

            var container = document.createElement('section');
            container.className = 'toDoList';
            container.setAttribute('name', 'toDoList' + counter);
            
            container.appendChild(containerHeader);
            container.appendChild(sectionsContainer);
            container.appendChild(inputField);
            container.appendChild(newSectionButton);

            this._htmlElement = container;
        }

        return Container;
    })();

    var Section = (function () {
        function Section(sectionTitle) {
            ListElement.call(this, sectionTitle);
        }

        Section.extends(ListElement);
        Section.prototype._buildHtmlElement = function () {
            var sectionHeader = document.createElement('h3');
            sectionHeader.innerHTML = this.getTitle();
            var sectionList = document.createElement('ul');

            var sectionListContainer = document.createElement('div');
            sectionListContainer.className = 'sectionList';
            sectionListContainer.appendChild(sectionHeader);
            sectionListContainer.appendChild(sectionList);

            var inputField = document.createElement('input');
            inputField.type = 'text';
            inputField.placeholder = 'Add item...';

            var addItemButton = document.createElement('button');
            addItemButton.className = 'addItemBtn';
            addItemButton.innerHTML = '+';
            addItemButton.addEventListener('click', function () {
                addNewListItem(sectionList, inputField.value);
                inputField.value = '';
            }, false);

            var sectionContainer = document.createElement('article');
            sectionContainer.appendChild(sectionListContainer);
            sectionContainer.appendChild(inputField);
            sectionContainer.appendChild(addItemButton);

            this._htmlElement = sectionContainer;
        }

        return Section;
    })();

    var ListItem = (function () {
        var counter = 0;
        function ListItem(content) {
            ListElement.call(this, content);
            counter += 1;
        }

        ListItem.extends(ListElement);
        ListItem.prototype._buildHtmlElement = function () {
            var inputField = document.createElement('input');
            inputField.type = 'checkbox';
            inputField.id = 'item' + counter;
            
            var label = document.createElement('label');
            label.innerHTML = this.getTitle();
            label.htmlFor = inputField.id;

            var itemContainer = document.createElement('li');
            itemContainer.className = 'notFinished';
            itemContainer.appendChild(inputField);
            itemContainer.appendChild(label);

            inputField.addEventListener('change', function () {
                if (inputField.checked) {
                    itemContainer.className = 'finished';
                } else {
                    itemContainer.className = 'notFinished';
                }
            }, false);

            this._htmlElement = itemContainer;
        }

        return ListItem;
    })();

    return {
        Container: Container,
        Section: Section,
        ListItem: ListItem
    }
})();