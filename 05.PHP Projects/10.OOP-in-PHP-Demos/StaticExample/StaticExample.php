<?php

class StaticExample
{
    const START = 500;
    private static $count = self::START;

    static function getNextCounter()
    {
        return ++static::$count;
    }
}

echo StaticExample::getNextCounter() . "\r\n";
echo StaticExample::getNextCounter() . "\r\n";
echo StaticExample::getNextCounter() . "\r\n";
